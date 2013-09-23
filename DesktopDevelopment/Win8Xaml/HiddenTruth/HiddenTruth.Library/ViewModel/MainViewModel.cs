using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using HiddenTruth.Library.Model;

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

        public PageModel CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; RaisePropertyChanged(() => CurrentPage); }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            LoadData(string.Empty);
        }

        private void LoadData(string pageToken)
        {
            DataService.GetBlogPosts(pageToken, (response, err) =>
            {
                if (err != null)
                {
                    System.Diagnostics.Debug.WriteLine(err.ToString());
                }
                else
                {
                    this.CurrentPage = response;
                }
            });
        }
    }
}