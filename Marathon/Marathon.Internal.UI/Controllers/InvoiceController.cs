using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marathon.Internal.UI.ViewModelMappers.Invoice;
using Marathon.Internal.UI.ActionFilters;
using Marathon.External.UI.ViewModels.Invoice;
using Marathon.Domain.Entities;
using Marathon.Domain.RepositoryContracts;
using Marathon.Domain.InfrastructureContracts;

namespace Marathon.Internal.UI.Controllers
{
    public class InvoiceController : Controller
    {
        private IGenerateViewModelMapper _generateViewModelMapper;
        private IInvoiceRepository _invoiceRepository;
        private IEmailer _emailer;

        public InvoiceController(
            IGenerateViewModelMapper generateViewModelMapper,
            IInvoiceRepository invoiceRepository,
            IEmailer emailer)
        {
            _generateViewModelMapper = generateViewModelMapper;
            _invoiceRepository = invoiceRepository;
            _emailer = emailer;
        }

        [EntityFrameworkReadContext]
        public ActionResult Generate()
        {
            var viewModel = _generateViewModelMapper.Map();
            return View(viewModel);
        }

        [HttpPost]
        [EntityFrameworkWriteContext]
        public ActionResult Generate(GenerateViewModel viewModel)
        {
            var request = _generateViewModelMapper.Map(viewModel);
            var validationMessages = Invoice.ValidateGenerate(request);
            validationMessages.ForEach(validationMessage => ModelState.AddModelError(validationMessage.Field, validationMessage.Text));

            if (!ModelState.IsValid)
            {
                _generateViewModelMapper.Hydrate(viewModel);
                return View(viewModel);
            }

            var invoice = Invoice.Generate(request, _emailer);
            _invoiceRepository.Save(invoice);
            return RedirectToAction("GenerateSuccess");
        }
    }
}
