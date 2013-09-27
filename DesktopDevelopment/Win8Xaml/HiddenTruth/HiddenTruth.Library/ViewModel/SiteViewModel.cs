using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HiddenTruth.Library.Model;
using HiddenTruth.Library.Services;

namespace HiddenTruth.Library.ViewModel
{
    public class SiteViewModel: ViewModelBase
    {
        private INavigationService _navigationService;
        private IServiceManager _serviceManager;
        private PageModel _currentPage;
        private ItemModel _selectedItem = new ItemModel();

        protected string CurrentSiteId { get; set; }
        public RelayCommand GoNextCommand { get; private set; }

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
                if (Set(SelectedItemPropertyName, ref _selectedItem, value)
                    && value != null)
                {
                    _navigationService.Navigate<ItemViewModel>(value);
                }
            }
        }

        public SiteViewModel(INavigationService navigationService, IServiceManager serviceManager)
        {
            _navigationService = navigationService;
            _serviceManager = serviceManager;
            this.GoNextCommand = new RelayCommand(this.ExecuteGoNextCommand);
        }

        private async void ExecuteGoNextCommand()
        {
            if (!string.IsNullOrEmpty(CurrentPage.NextPageToken))
            {
                await LoadData(CurrentSiteId, CurrentPage.PageIndex.ToString());
            }
        }

        public async Task LoadData(string siteId, string pageIndex)
        {
            CurrentSiteId = siteId;
            var site = ServiceManager.Sites.FirstOrDefault(x => x.Id == siteId);
            if (site != null)
            {
                string pageToken = null;
                if (pageIndex != null)
                {
                    pageToken = site.Pages[Convert.ToInt16(pageIndex)].NextPageToken;
                }
                switch (site.Title)
                {
                    case "Alter Information":
                        await _serviceManager.GetDataAlterInformation(pageToken, (response, err) => LoadDataCompleted(err, response));
                        break;
                    default:
                        await _serviceManager.GetDataBlogZaSeriozniHora(pageToken, (response, err) => LoadDataCompleted(err, response));
                        break;
                }
            }
        }

        private void LoadDataCompleted(Exception err, PageModel response)
        {
            if (err != null)
            {
                System.Diagnostics.Debug.WriteLine(err.ToString());
            }
            else
            {
                this.CurrentPage = response;
            }
        }
    }
}
