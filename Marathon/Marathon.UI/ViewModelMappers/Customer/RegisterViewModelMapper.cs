using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marathon.Domain.RepositoryContracts;
using Marathon.UI.ViewModels.Customer;
using Marathon.Domain.Requests;
using Marathon.Domain.Constants;

namespace Marathon.UI.ViewModelMappers.Customer
{
    public class RegisterViewModelMapper : Marathon.UI.ViewModelMappers.Customer.IRegisterViewModelMapper
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;

        public RegisterViewModelMapper(
            IUserRepository userRepository,
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public RegisterCustomerRequest Map(RegisterViewModel viewModel)
        {
            var request = new RegisterCustomerRequest();
            request.ApplicationUser = _userRepository.GetById(UserIds.Application);
            request.CustomerRole = _roleRepository.GetById(RoleIds.Customer);
            request.EmailAddress = viewModel.EmailAddress;
            request.FamilyName = viewModel.FamilyName;
            request.GivenName = viewModel.GivenName;
            request.Address1 = viewModel.Address1;
            request.Address2 = viewModel.Address2;
            request.Address3 = viewModel.Address3;
            request.Address4 = viewModel.Address4;
            request.PostCode = request.PostCode;
            return request;
        }
    }
}