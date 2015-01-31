using System;
using Marathon.Domain.Requests;
using Marathon.External.UI.ViewModels.Customer;

namespace Marathon.External.UI.ViewModelMappers.Customer
{
    public interface IRegisterViewModelMapper
    {
        RegisterCustomerRequest Map(RegisterViewModel viewModel);
    }
}
