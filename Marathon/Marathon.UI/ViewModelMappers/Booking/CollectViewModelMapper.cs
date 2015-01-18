using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marathon.UI.ViewModels.Booking;

namespace Marathon.UI.ViewModelMappers.Booking
{
    public class CollectViewModelMapper : ICollectViewModelMapper
    {
        public CollectViewModel New()
        {
            var viewModel = new CollectViewModel();
            return viewModel;
        }
    }
}