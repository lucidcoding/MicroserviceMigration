using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marathon.External.UI.ViewModels.Booking;
using Marathon.Domain.Requests;
using Marathon.External.UI.Security;
using Marathon.Domain.RepositoryContracts;

namespace Marathon.External.UI.ViewModelMappers.Booking
{
    public class ReturnViewModelMapper : IReturnViewModelMapper
    {
        private IUserRepository _userRepository;
        private IUserProvider _userProvider;

        public ReturnViewModelMapper(
            IUserRepository userRepository,
            IUserProvider userProvider)
        {
            _userRepository = userRepository;
            _userProvider = userProvider;
        }

        public ReturnViewModel New()
        {
            var viewModel = new ReturnViewModel();
            return viewModel;
        }

        public ReturnBookingRequest Map(ReturnViewModel viewModel)
        {
            var request = new ReturnBookingRequest();
            request.Mileage = viewModel.Mileage;
            var username = _userProvider.GetUsername();
            request.LoggedBy = _userRepository.GetByUsername(username);
            return request;
        }
    }
}