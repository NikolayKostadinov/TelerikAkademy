using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using HiddenTruth.Library.Services;

namespace HiddenTruth.Library.ViewModel
{
    public class CustomAppBarViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IServiceManager _serviceManager;

        public CustomAppBarViewModel(INavigationService navigationService, IServiceManager serviceManager)
        {
            _navigationService = navigationService;
            _serviceManager = serviceManager;
        }
    }
}
