using System;
using Marathon.Domain.Requests;
using Marathon.UI.ViewModels.Customer;

namespace Marathon.UI.ViewModelMappers.Customer
{
    public interface IRegisterViewModelMapper
    {
        RegisterCustomerRequest Map(RegisterViewModel viewModel);
    }
}
