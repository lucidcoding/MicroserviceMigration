using System;
using Marathon.External.UI.ViewModels.Invoice;

namespace Marathon.Internal.UI.ViewModelMappers.Invoice
{
    public interface IGenerateViewModelMapper
    {
        void Hydrate(GenerateViewModel viewModel);
        GenerateViewModel Map();
    }
}
