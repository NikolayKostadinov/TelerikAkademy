using System;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using HiddenTruth.Library.Model;
using HiddenTruth.Library.Services;
using HiddenTruth.Library.Utils;

namespace HiddenTruth.Library.ViewModel
{
    public class SiteViewModel: ViewModelBase
    {
        public readonly INavigationService _navigationService;
        public readonly IServiceManager _serviceManager;
        private SiteModel _currentSite;

        public SiteModel CurrentSite
        {
            get { return _currentSite; }
            set
            {
                if (value != _currentSite)
                {
                    _currentSite = value;
                    RaisePropertyChanged(() => CurrentSite);
                }
            }
        }

        public SiteViewModel(INavigationService navigationService, IServiceManager serviceManager)
        {
            _navigationService = navigationService;
            _serviceManager = serviceManager;
        }

        public async Task LoadData(string siteId, string pageToken)
        {
            CurrentSite = ServiceManager.Sites.FirstOrDefault(x => x.Id == siteId);
            if (CurrentSite != null)
            {
                switch (CurrentSite.Title)
                {
                    case "Alter Information":
                        await _serviceManager.GetDataAlterInformation(pageToken.ToInt(1), (response, err) => LoadDataCompleted(err, response));
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
        }
    }
}
