using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using HiddenTruth.BackgroundTasks;
using HiddenTruth.Library.Model;
using HiddenTruth.Library.Utils;
using HiddenTruth.Library.ViewModel;
using HiddenTruth.Store.Common;
using HiddenTruth.Store.Data;
// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233
using MyToolkit.Controls;

namespace HiddenTruth.Store.View
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split App this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class SitesView : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        public SitesView()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            var titleDetailsViewModel = DataContext as SiteViewModel;
            if (titleDetailsViewModel != null)
            {
                var parameters = e.NavigationParameter as List<string>;
                if (parameters != null && parameters.Count == 2)
                {
                    await titleDetailsViewModel.LoadData(parameters[0], parameters[1]);
                    //foreach (var pageModel in titleDetailsViewModel.CurrentSite.Pages)
                    //{
                    //    foreach (var itemModel in pageModel.Items)
                    //    {
                    //        ClockTileScheduler.TileModels.AddSafe(itemModel.Title, itemModel.ImagePath);
                    //    }
                    //}
                }
            }

            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            //var sampleDataGroups = await SampleDataSource.GetGroupsAsync();
            //this.DefaultViewModel["Items"] = sampleDataGroups;
        }

        /// <summary>
        /// Invoked when an item is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            var groupId = ((SampleDataGroup)e.ClickedItem).UniqueId;
            this.Frame.Navigate(typeof(ItemView), groupId);
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            var titleDetailsViewModel = DataContext as SiteViewModel;
            if (titleDetailsViewModel != null)
            {
                titleDetailsViewModel.CurrentSite.SelectedIndex = PnlPivot.SelectedIndex;
            }
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private async void PnlPivot_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var actionPivot = sender as ExtendedListBox;
            if (actionPivot != null)
            {
                var titleDetailsViewModel = DataContext as SiteViewModel;
                if (titleDetailsViewModel != null)
                {
                    if (actionPivot.SelectedIndex == titleDetailsViewModel.CurrentSite.Pages.Count - 1)
                    {
                        await titleDetailsViewModel.LoadData(titleDetailsViewModel.CurrentSite.Id, 
                                                    titleDetailsViewModel.CurrentSite.Pages[actionPivot.SelectedIndex].NextPageToken);
                        if (actionPivot.SelectedIndex + 1 < titleDetailsViewModel.CurrentSite.Pages.Count)
                        {
                            int pageIndex = actionPivot.SelectedIndex + 1;
                            AddPivotItem(pageIndex, titleDetailsViewModel);
                        }
                    }
                }
            }
        }

        private void PnlPivot_OnLoaded(object sender, RoutedEventArgs e)
        {
            var titleDetailsViewModel = DataContext as SiteViewModel;
            if (titleDetailsViewModel != null)
            {
                if (titleDetailsViewModel.CurrentSite.Pages.Count > 0)
                {
                    //PnlPivot.Items[0].DataContext = new PivotItemViewModel(titleDetailsViewModel.CurrentSite.Pages[0]);
                    var pivotItemTemplate = PnlPivot.Items[0].Content as PivotItemTemplate;
                    if (pivotItemTemplate != null)
                    {
                        pivotItemTemplate.DataContext = new PivotItemViewModel(titleDetailsViewModel._navigationService, titleDetailsViewModel._serviceManager, titleDetailsViewModel.CurrentSite.Pages[0]);
                    }
                    if (PnlPivot.Items.Count < titleDetailsViewModel.CurrentSite.Pages.Count)
                    {
                        for (int i = PnlPivot.Items.Count; i < titleDetailsViewModel.CurrentSite.Pages.Count; i++)
                        {
                            AddPivotItem(i, titleDetailsViewModel);
                        }
                    }
                    if (titleDetailsViewModel.CurrentSite.SelectedIndex < PnlPivot.Items.Count)
                    {
                        PnlPivot.SelectedIndex = titleDetailsViewModel.CurrentSite.SelectedIndex;
                    }
                }
            }
        }

        private void AddPivotItem(int pageIndex, SiteViewModel titleDetailsViewModel)
        {
            PnlPivot.Items.Add(new PivotItem()
            {
                Content = new PivotItemTemplate()
                {
                    DataContext = new PivotItemViewModel(titleDetailsViewModel._navigationService, titleDetailsViewModel._serviceManager, titleDetailsViewModel.CurrentSite.Pages[pageIndex])
                },
                Header = "Page" + (pageIndex + 1),
            });
        }

        public static string page;
        public static int counter = 1;
        private static Guid logoSecondaryTileId = Guid.NewGuid();
        public static string dynamicTileId = "SecondaryTile.LiveTile";
        public static string appbarTileId = "SecondaryTile.AppBar";

        private async void BtnPinSecondaryTile_OnClick(object sender, RoutedEventArgs e)
        {
            Uri logo = new Uri("ms-appx:///Assets/Images/150x150.png");
            Uri smallLogo = new Uri("ms-appx:///Assets/Images/310x150.png");

            // During creation of secondary tile, an application may set additional arguments on the tile that will be passed in during activation.
            // These arguments should be meaningful to the application. In this sample, we'll pass in the date and time the secondary tile was pinned.
            string tileActivationArguments = logoSecondaryTileId + " WasPinnedAt=" + DateTime.Now.ToLocalTime().ToString();
            counter++;
            // Create a 1x1 Secondary tile
            SecondaryTile s = new SecondaryTile(logoSecondaryTileId.ToString(),
                                                                "Hidden Truth Blog page",
                                                                "Hidden Truth Blog page",
                                                                tileActivationArguments,
                                                                TileOptions.ShowNameOnLogo,
                                                                logo);
            s.DisplayName = "Hidden Truth";
            // Specify a foreground text value.
            s.ForegroundText = ForegroundText.Dark;
            bool isPinned = await s.RequestCreateForSelectionAsync(GetElementRect((FrameworkElement)sender), Windows.UI.Popups.Placement.Below);
            // OK, the tile is created and we can now attempt to pin the tile.
            // Note that the status message is updated when the async operation to pin the tile completes.
        }

        public static Rect GetElementRect(FrameworkElement element)
        {
            GeneralTransform buttonTransform = element.TransformToVisual(null);
            Point point = buttonTransform.TransformPoint(new Point());
            return new Rect(point, new Size(element.ActualWidth, element.ActualHeight));
        }
    }
}
