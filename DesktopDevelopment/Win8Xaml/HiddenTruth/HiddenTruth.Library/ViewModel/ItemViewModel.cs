using GalaSoft.MvvmLight;
using HiddenTruth.Library.Model;
using HiddenTruth.Library.Services;

namespace HiddenTruth.Library.ViewModel
{
    public class ItemViewModel: ViewModelBase
    {
        private INavigationService _navigationService;
        private IServiceManager _serviceManager;
        private PageModel _currentPage;
        private ItemModel _selectedItem = new ItemModel();

        public PageModel CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                RaisePropertyChanged(() => CurrentPage);
            }
        }

        public const string SelectedItemPropertyName = "SelectedItem";

        public ItemModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                Set(SelectedItemPropertyName, ref _selectedItem, value);
            }
        }

        public ItemViewModel(INavigationService navigationService, IServiceManager serviceManager)
        {
            _navigationService = navigationService;
            _serviceManager = serviceManager;
        }
    }
}
