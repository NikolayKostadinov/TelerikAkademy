﻿using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using HiddenTruth.Library.Services;
using HiddenTruth.Library.ViewModel;
using HiddenTruth.Store.View;

namespace HiddenTruth.Store.Services
{
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// The view model routing.
        /// </summary>
        private static readonly IDictionary<Type, Type> ViewModelRouting = new Dictionary<Type, Type>()
        {
            {
                typeof (MainViewModel), typeof (MainPage)
            },
            {
                typeof (SiteViewModel), typeof (SitesView)
            },
            {
                typeof (ItemViewModel), typeof (ItemView)
            },
            {
                typeof (PivotItemViewModel), typeof (PivotItemTemplate)
            },
            {
                typeof (SearchResultViewModel), typeof (SearchResultView)
            },
            {
                typeof (CustomAppBarViewModel), typeof (TopCustomAppBarUserControl)
            }
        };

        /// <summary>
        /// Gets a value indicating whether can go back.
        /// </summary>
        public bool CanGoBack
        {
            get
            {
                return RootFrame.CanGoBack;
            }
        }

        /// <summary>
        /// Gets the root frame.
        /// </summary>
        private static Frame RootFrame
        {
            get { return Window.Current.Content as Frame; }
        }

        /// <summary>
        /// The go back.
        /// </summary>
        public void GoBack()
        {
            RootFrame.GoBack();
        }

        /// <summary>
        /// Navigates the specified parameter.
        /// </summary>
        /// <typeparam name="TDestinationViewModel">
        /// The type of the destination view model.
        /// </typeparam>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public void Navigate<TDestinationViewModel>(object parameter)
        {
            var dest = ViewModelRouting[typeof(TDestinationViewModel)];

            RootFrame.Navigate(dest, parameter);
        }
    }
}
