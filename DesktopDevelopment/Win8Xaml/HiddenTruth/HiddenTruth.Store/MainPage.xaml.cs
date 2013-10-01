using System.Globalization;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;
using HiddenTruth.BackgroundTasks;
using HiddenTruth.Library.Model;
using HiddenTruth.Library.Utils;
using HiddenTruth.Library.ViewModel;
using HiddenTruth.Store.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using HiddenTruth.Library.Helpers;
// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237
using NotificationsExtensions.TileContent;

namespace HiddenTruth.Store
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string TASKNAMEUSERPRESENT = "TileSchedulerTaskUserPresent";
        private const string TASKNAMETIMER = "TileSchedulerTaskTimer";
        private const string TASKENTRYPOINT = "HiddenTruth.BackgroundTasks.TileSchedulerTask";

        //private const string TASK_NAME = "TileUpdater";
        //private const string TASK_ENTRY = "HiddenTruth.BackgroundTasks.TileUpdater";
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

        public MainPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
            this.Loaded += MainPage_Loaded;
        }

        void MainPage_LayoutUpdated(object sender, object e)
        {
            
        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //await RegisterBackgroundNotifications();
            
        }

        private static async void CreateClockTask()
        {
            var result = await BackgroundExecutionManager.RequestAccessAsync();
            if (result == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity ||
                result == BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity)
            {
                await Task.Run(() => ClockTileScheduler.CreateSchedule());

                EnsureUserPresentTask();
                EnsureTimerTask();
            }
        }

        private static void EnsureUserPresentTask()
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks)
                if (task.Value.Name == TASKNAMEUSERPRESENT)
                    return;

            BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
            builder.Name = TASKNAMEUSERPRESENT;
            builder.TaskEntryPoint = TASKENTRYPOINT;
            builder.SetTrigger(new SystemTrigger(SystemTriggerType.UserPresent, false));
            builder.Register();
        }

        private static void EnsureTimerTask()
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks)
                if (task.Value.Name == TASKNAMETIMER)
                    return;

            BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
            builder.Name = TASKNAMETIMER;
            builder.TaskEntryPoint = TASKENTRYPOINT;
            builder.SetTrigger(new TimeTrigger(180, false));
            builder.Register();
        }

        //private static async Task RegisterBackgroundNotifications()
        //{
        //    var result = await BackgroundExecutionManager.RequestAccessAsync();
        //    if (result == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity ||
        //        result == BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity)
        //    {
        //        foreach (var task in BackgroundTaskRegistration.AllTasks)
        //        {
        //            if (task.Value.Name == TASK_NAME)
        //                task.Value.Unregister(true);
        //        }

        //        BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
        //        builder.Name = TASK_NAME;
        //        builder.TaskEntryPoint = TASK_ENTRY;
        //        builder.SetTrigger(new TimeTrigger(15, false));
        //        var registration = builder.Register();
        //    }
        //}

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            var titleDetailsViewModel = DataContext as MainViewModel;
            if (titleDetailsViewModel != null)
            {
                await titleDetailsViewModel.LoadData(null);
               
            }
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            
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

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                var titleDetailsViewModel = DataContext as MainViewModel;
                if (titleDetailsViewModel != null)
                {
                    itemGridView.SelectedIndex = -1;
                    titleDetailsViewModel.NavigationModeIsBack = true;
                }
            }

            //var ds = this.DataContext as MainViewModel;
            //if (ds != null)
            //{
            //    ds.Sites.CollectionChanged += Sites_CollectionChanged;
            //}

            CreateClockTask();

            navigationHelper.OnNavigatedTo(e);
        }

        //void Sites_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.NewItems.Count > 0)
        //    {
        //        foreach (SiteModel item in e.NewItems)
        //        {
        //            item.Pages.CollectionChanged += Pages_CollectionChanged;
        //        }
        //    }
        //}

        //void Pages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.NewItems.Count > 0)
        //    {
        //        foreach (PageModel page in e.NewItems)
        //        {
        //            foreach (var item in page.Items)
        //            {
        //                if (ValidateAndGetUri(item.ImagePath))
        //                {
        //                    ClockTileScheduler.TileModels.AddSafe(item.Title, item.ImagePath);
        //                }
        //            }
        //        }
        //    }
        //}

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private bool ValidateAndGetUri(string uriString)
        {
            Uri uri = null;
            try
            {
                uri = new Uri(uriString);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        //private static void AddInitTiles(string title, string imageUri)
        //{
        //    // Create notification square310x310 content based on a visual template.
        //    ITileSquare310x310Image tileContent = TileContentFactory.CreateTileSquare310x310Image();
        //    tileContent.AddImageQuery = true;
        //    tileContent.Image.Src = imageUri;
        //    tileContent.Image.Alt = title;

        //    // create the notification for a wide310x150 template.
        //    ITileWide310x150ImageAndText01 wide310x150Content = TileContentFactory.CreateTileWide310x150ImageAndText01();
        //    wide310x150Content.TextCaptionWrap.Text = title;
        //    wide310x150Content.Image.Src = imageUri;
        //    wide310x150Content.Image.Alt = title;

        //    // create the square150x150 template and attach it to the wide310x150 template.
        //    ITileSquare150x150Image square150x150Content = TileContentFactory.CreateTileSquare150x150Image();
        //    square150x150Content.Image.Src = imageUri;
        //    square150x150Content.Image.Alt = title;

        //    // add the square150x150 template to the wide310x150 template.
        //    wide310x150Content.Square150x150Content = square150x150Content;

        //    // add the wide310x150 to the Square310x310 template.
        //    tileContent.Wide310x150Content = wide310x150Content;

        //    // send the notification to the app's application tile.
        //    TileUpdateManager.CreateTileUpdaterForApplication().Update(tileContent.CreateNotification());
        //}
    }
}
