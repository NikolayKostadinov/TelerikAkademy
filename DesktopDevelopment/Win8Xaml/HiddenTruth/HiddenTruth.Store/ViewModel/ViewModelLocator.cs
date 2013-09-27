/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Mvvm.Store"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using HiddenTruth.Library.Model;
using HiddenTruth.Library.Services;
using HiddenTruth.Library.ViewModel;
using HiddenTruth.Store.Services;
using Microsoft.Practices.ServiceLocation;

namespace HiddenTruth.Store.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (!SimpleIoc.Default.IsRegistered<IServiceManager>())
            {
                // For use the fake data do:
                // FakeServiceManager.FakeImagePath = "ms-appx:///Images/FakeImage.png";
                // SimpleIoc.Default.Register<IServiceManager, FakeServiceManager>();
                SimpleIoc.Default.Register<IServiceManager, ServiceManager>();

                SimpleIoc.Default.Register<INavigationService>(() => new NavigationService());
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SiteViewModel>();
            SimpleIoc.Default.Register<ItemViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public SiteViewModel Site
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SiteViewModel>();
            }
        }

        public ItemViewModel Item
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ItemViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}