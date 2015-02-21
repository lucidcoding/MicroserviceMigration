using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marathon.Domain.RepositoryContracts;
using Marathon.External.UI.ViewModels.Invoice;
using System.Web.Mvc;
using Marathon.Internal.UI.Extensions;
using Marathon.Domain.Requests;
using Marathon.Internal.UI.Security;

namespace Marathon.Internal.UI.ViewModelMappers.Invoice
{
    public class GenerateViewModelMapper : IGenerateViewModelMapper
    {
        private ICustomerRepository _customerRepository;
        private IUserRepository _userRepository;
        private IUserProvider _userProvider;

        public GenerateViewModelMapper(
            ICustomerRepository customerRepository,
            IUserRepository userRepository,
            IUserProvider userProvider)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _userProvider = userProvider;
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

        public GenerateInvoiceRequest Map(GenerateViewModel viewModel)
        {
            var request = new GenerateInvoiceRequest();
            request.PeriodFrom = viewModel.PeriodFrom;
            request.PeriodTo = viewModel.PeriodTo;
            request.Customer = _customerRepository.GetById(viewModel.CustomerId.Value);
            var username = _userProvider.GetUsername();
            request.GeneratedBy = _userRepository.GetByUsername(username);
            return request;
        }
    }
}