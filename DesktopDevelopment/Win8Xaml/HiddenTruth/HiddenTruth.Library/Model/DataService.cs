using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Google.Apis.Blogger.v3;
using Google.Apis.Blogger.v3.Data;
using Google.Apis.Services;
using HtmlAgilityPack;

namespace HiddenTruth.Library.Model
{

    public static class DataService
    {
        public static ObservableCollection<PageModel> PageLists { get; set; }

        private static readonly string uri = "http://blogzaserioznihora.blogspot.com/";

        static DataService()
        {
            PageLists = new ObservableCollection<PageModel>();
        }

        public static async void GetBlogPosts(string pageToken, Action<PageModel, Exception> callback)
        {
            Exception err = null;
            var result = new PageModel();
            try
            {
                PageModel pm = PageLists.FirstOrDefault(x => x.CurrentPageToken == pageToken);
                if (pm != null)
                {
                    result = pm;
                }
                else
                {
                    BloggerService _service = new BloggerService(new BaseClientService.Initializer()
                    {
                        ApiKey = "AIzaSyCkyf5p4x_2tW-Bwmqt7Bbj-HhFIC_kXvw",
                    });

                    var blog = await _service.Blogs.GetByUrl(uri).ExecuteAsync();
                    var getPosts = _service.Posts.List(blog.Id.ToString());
                    getPosts.MaxResults = 9;
                    if (!string.IsNullOrEmpty(pageToken))
                    {
                        getPosts.PageToken = pageToken;
                        result.CurrentPageToken = pageToken;
                    }

                    var response = await getPosts.ExecuteAsync();
                    result.NextPageToken = response.NextPageToken;
                    result.PrevPageToken = response.PrevPageToken;
                    foreach (var item in response.Items)
                    {
                        var itemModel = new ItemModel()
                        {
                            GroupIndex = PageLists.Count,
                            Post = item,
                            Title = item.Title
                        };

                        var document = new HtmlDocument();
                        document.LoadHtml(item.Content);
                        var img = document.DocumentNode.Descendants().FirstOrDefault(doc => doc.Name == "img");
                        if (img != null)
                        {
                            itemModel.ImagePath = img.Attributes["src"].Value;
                        }

                        result.Items.Add(itemModel);
                    }
                    PageLists.Add(result);
                }
            }
            catch (Exception ex)
            {
                err = ex;
            }

            callback(result, err);
        }

        public static async Task<PageModel> GetGroupAsync(int groupIndex)
        {
            // Simple linear search is acceptable for small data sets
            var matches = PageLists[groupIndex];
            return matches;
        }

        public static async Task<ItemModel> GetItemAsync(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = PageLists.SelectMany(group => group.Items).Where((item) => item.Post.Id.Equals(uniqueId));
            if (matches.Count() == 1)
            {
                return matches.First();
            }
            return null;
        }

        /*
        public async void GetHeadlines(Action<List<PageModel>, Exception> callback)
        {

            // locally scoped exception var
            Exception err = null;
            List<PageModel> results = null;

            try
            {
                var t = await MakeAsyncRequest(uri);

                StringReader stringReader = new StringReader(t);
                using (var xmlReader = System.Xml.XmlReader.Create(stringReader))
                {
                    var doc = System.Xml.Linq.XDocument.Load(xmlReader);

                    //results = (from e in doc.Element("rss").Element("channel").Elements("item")
                    //           select
                    //               new Headline()
                    //               {
                    //                   Title = e.Element("title").Value,
                    //                   Description = e.Element("description").Value,
                    //                   Published = Convert.ToDateTime(e.Element("pubDate").Value),
                    //                   Url = e.Element("link").Value

                    //               }).ToList();
                }
            }
            catch (Exception ex)
            {
                // should do some other 
                // logging here. for now pass off
                // exception to callback on UI
                err = ex;
            }

            callback(results, err);

        }

        private static Task<string> MakeAsyncRequest(string url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);

            request.Method = "GET";

            Task<WebResponse> task = Task.Factory.FromAsync(
                request.BeginGetResponse,
                (asyncResult) => request.EndGetResponse(asyncResult),
                (object)null);

            return task.ContinueWith(t => ReadStreamFromResponse(t.Result));
        }

        private static string ReadStreamFromResponse(WebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader sr = new StreamReader(responseStream))
            {
                string strContent = sr.ReadToEnd();

                return strContent;
            }
        }
         */
    }
}
