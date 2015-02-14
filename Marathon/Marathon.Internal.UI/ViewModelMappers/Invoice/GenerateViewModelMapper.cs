using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marathon.Domain.RepositoryContracts;
using Marathon.External.UI.ViewModels.Invoice;
using System.Web.Mvc;
using Marathon.Internal.UI.Extensions;

namespace Marathon.Internal.UI.ViewModelMappers.Invoice
{
    public class GenerateViewModelMapper : IGenerateViewModelMapper
    {
        public ICustomerRepository _customerRepository;

        public GenerateViewModelMapper(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public GenerateViewModel Map()
        {
            var viewModel = new GenerateViewModel();
            viewModel.PeriodFrom = DateTime.Now.AddMonths(-1).Date;
            viewModel.PeriodTo = DateTime.Now.Date;
            Hydrate(viewModel);
            return viewModel;
        }

        public void Hydrate(GenerateViewModel viewModel)
        {
            var customers = _customerRepository.GetAllOrderedByFamilyName();

            viewModel.CustomerOptions = new SelectList(customers.Select(customer => 
                new SelectListItem{ Text = customer.FamilyName  + ", " + customer.GivenName, Value = customer.Id.Value.ToString() }), "Value", "Text")
                .AddDefaultOption();
        }
    }
}