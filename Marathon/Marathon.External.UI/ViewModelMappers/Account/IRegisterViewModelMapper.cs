using System;
using Marathon.Domain.Requests;
using Marathon.External.UI.ViewModels.Account;

namespace Marathon.External.UI.ViewModelMappers.Account
{
    public interface IRegisterViewModelMapper
    {
        RegisterCustomerRequest Map(RegisterViewModel viewModel);
    }
}
