using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Capture;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using HtmlAgilityPack;

namespace HiddenTruth.Store.Behaviors
{
    public static class WebViewHelper
    {
        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached(
            "Html", typeof(string), typeof(WebViewHelper), new PropertyMetadata(null, OnHtmlChanged));

        public static string GetHtml(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(HtmlProperty);
        }

        public static void SetHtml(DependencyObject dependencyObject, string value)
        {
            dependencyObject.SetValue(HtmlProperty, value);
        }

        private static void OnHtmlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var browser = d as WebView;

            if (browser == null)
                return;

            if (e.NewValue != null)
            {
                var html = e.NewValue.ToString();

                var document = new HtmlDocument();
                document.LoadHtml(html);
                var iframes = document.DocumentNode.Descendants().Where(doc => doc.Name == "iframe");
                foreach (var htmlNode in iframes)
                {
                    var url = htmlNode.Attributes["src"].Value;
                    if (!url.StartsWith("http://"))
                    {
                        url = CheckUrl(url);
                        htmlNode.Attributes["src"].Value = "http://" + url;
                    }
                }
                //html = "<iframe frameborder='0' height='350' src='http://www.youtube.com/embed/2zfqw8nhUwA' width='450'></iframe>";
                browser.NavigateToString(document.DocumentNode.OuterHtml);
                //browser.Visibility = Visibility.Visible;
            }
            //browser.Visibility = Visibility.Collapsed;
        }

        private static string CheckUrl(string url)
        {
            if (!url.StartsWith("w"))
            {
                url = url.Remove(0, 1);
                url = CheckUrl(url);
            }
            return url;
        }
    }
}
