﻿using Windows.UI.Xaml.Documents;
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

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace HiddenTruth.Store.View
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class PrintPage : Page
    {

        public PrintPage()
        {
            this.InitializeComponent();
        }

        public PrintPage(RichTextBlockOverflow textLinkContainer)
            : this()
        {
            textLinkContainer.OverflowContentTarget = continuationPageLinkedContainer;
        }

        internal void AddContent(Paragraph block)
        {
            this.textContent.Blocks.Add(block);
        }
    }
}
