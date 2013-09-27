using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HiddenTruth.Library.Helpers;
using HiddenTruth.Library.Model;
using HiddenTruth.Library.Services;

namespace HiddenTruth.Library.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private PageModel _currentPage;
        private ItemModel _selectedItem = new ItemModel();
        private readonly INavigationService _navigationService;
        private readonly IServiceManager _serviceManager;

        public RelayCommand HeaderClickCommand { get; set; }

        private RelayCommand<string> _goToCommand;
        public RelayCommand<string> GoToCommand
        {
            get
            {
                if (_goToCommand == null)
                {
                    _goToCommand = new RelayCommand<string>(NavigateAway);
                }
                return _goToCommand;
            }
        }

        private void NavigateAway(string parameter)
        {
            var parameters = new List<string>();
            parameters.Add(parameter);
            parameters.Add(null);
            _navigationService.Navigate<SiteViewModel>(parameters);
        }

        public PageModel CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                RaisePropertyChanged(() => CurrentPage);
            }
        }

        public ObservableCollection<SiteModel> Sites
        {
            get
            {
                return ServiceManager.Sites;
            }
        } 

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(INavigationService navigationService, IServiceManager serviceManager)
        {
            _navigationService = navigationService;
            _serviceManager = serviceManager;
            LoadData(string.Empty);
        }

        /// <summary>
        /// The <see cref="SelectedItem" /> property's name.
        /// </summary>
        public const string SelectedItemPropertyName = "SelectedItem";

        /// <summary>
        /// Sets and gets the SelectedFriend property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ItemModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                //_selectedItem = value;
                //RaisePropertyChanged("SelectedItem");
                if (Set(SelectedItemPropertyName, ref _selectedItem, value)
                    && value != null)
                {
                    _navigationService.Navigate<SiteViewModel>(value);
                }
            }
        }

        private void LoadData(string pageToken)
        {
            _serviceManager.GetDataBlogZaSeriozniHora(pageToken, (response, err) =>
            {
                if (err != null)
                {
                    System.Diagnostics.Debug.WriteLine(err.ToString());
                }
                else
                {
                    this.CurrentPage = response;
                    SiteModel site = Sites.FirstOrDefault(x => x.Title == "Блог за сериозни хора");
                    if (site != null)
                    {
                        foreach (var item in response.Items)
                        {
                            site.Items.Add(item);
                        }
                        
                    }
                }
            });

            _serviceManager.GetDataAlterInformation("1", (model, exception) =>
            {
                if (exception != null)
                {
                    System.Diagnostics.Debug.WriteLine(exception.ToString());
                }
                else
                {
                    this.CurrentPage = model;
                    SiteModel site = Sites.FirstOrDefault(x => x.Title == "Alter Information");
                    if (site != null)
                    {
                        foreach (var item in model.Items)
                        {
                            site.Items.Add(item);
                        }
                    }
                }
            });
        }
    }
}