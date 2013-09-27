using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using HiddenTruth.Library.Model;
using HiddenTruth.Library.Services;

namespace HiddenTruth.Library.ViewModel
{
    public class SiteViewModel: ViewModelBase
    {
        private INavigationService _navigationService;
        private IServiceManager _serviceManager;
        private PageModel _currentPage;

        public PageModel CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                RaisePropertyChanged(() => CurrentPage);
            }
        }

        public SiteViewModel(INavigationService navigationService, IServiceManager serviceManager)
        {
            _navigationService = navigationService;
            _serviceManager = serviceManager;
        }

        public void LoadData(string siteId, string pageIndex)
        {
            SiteModel site = ServiceManager.Sites.FirstOrDefault(x => x.Id == siteId);
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
                        _serviceManager.GetDataAlterInformation(pageToken, (response, err) => LoadDataCompleted(err, response, site));
                        break;
                    default:
                        _serviceManager.GetDataBlogZaSeriozniHora(pageToken, (response, err) => LoadDataCompleted(err, response, site));
                        break;
                }
            }
        }

        private void LoadDataCompleted(Exception err, PageModel response, SiteModel site)
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
