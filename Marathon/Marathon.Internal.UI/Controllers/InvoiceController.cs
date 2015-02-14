using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marathon.Internal.UI.ViewModelMappers.Invoice;
using Marathon.Internal.UI.ActionFilters;
using Marathon.External.UI.ViewModels.Invoice;

namespace Marathon.Internal.UI.Controllers
{
    public class InvoiceController : Controller
    {
        private IGenerateViewModelMapper _generateViewModelMapper;

        public InvoiceController(IGenerateViewModelMapper generateViewModelMapper)
        {
            _generateViewModelMapper = generateViewModelMapper;
        }

        [EntityFrameworkReadContext]
        public ActionResult Generate()
        {
            var viewModel = _generateViewModelMapper.Map();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Generate(GenerateViewModel viewModel)
        {
            return View();
        }
    }
}
