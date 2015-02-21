using System;
using Marathon.External.UI.ViewModels.Invoice;
using Marathon.Domain.Requests;

namespace Marathon.Internal.UI.ViewModelMappers.Invoice
{
    public interface IGenerateViewModelMapper
    {
        void Hydrate(GenerateViewModel viewModel);
        GenerateViewModel Map();
        GenerateInvoiceRequest Map(GenerateViewModel viewModel);
    }
}
