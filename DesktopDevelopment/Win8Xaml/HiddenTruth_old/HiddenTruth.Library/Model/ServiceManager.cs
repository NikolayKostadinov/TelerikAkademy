using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Google.Apis.Blogger.v3;
using Google.Apis.Services;
using HiddenTruth.Library.Model.AlterInformation;
using HiddenTruth.Library.Services;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace HiddenTruth.Library.Model
{

    public class ServiceManager : IServiceManager
    {
        public static ObservableCollection<SiteModel> Sites { get; set; }

        static ServiceManager()
        {
            Sites = new ObservableCollection<SiteModel>();
        }

        public async void GetDataBlogZaSeriozniHora(string pageToken, Action<PageModel, Exception> callback)
        {
            string uri = "http://blogzaserioznihora.blogspot.com/";

            Exception err = null;
            var result = new PageModel();
            try
            {
                BloggerService _service = new BloggerService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyCkyf5p4x_2tW-Bwmqt7Bbj-HhFIC_kXvw",
                });

                SiteModel site = Sites.FirstOrDefault(x => x.Title == "Блог за сериозни хора");
                if (site == null)
                {
                    var blog = await _service.Blogs.GetByUrl(uri).ExecuteAsync();
                    site = new SiteModel()
                    {
                        Title = "Блог за сериозни хора",
                        Id = blog.Id
                    };
                    
                    //group.ImagePath = blog.
                    Sites.Add(site);
                }

                PageModel page = site.Pages.FirstOrDefault(x => x.CurrentPageToken == pageToken);
                if (page != null)
                {
                    result = page;
                }
                else
                {
                    var getPosts = _service.Posts.List(site.Id);
                    getPosts.MaxResults = 10;
                    if (!string.IsNullOrEmpty(pageToken))
                    {
                        getPosts.PageToken = pageToken;
                        result.CurrentPageToken = pageToken;
                    }

                    var response = await getPosts.ExecuteAsync();
                    result.NextPageToken = response.NextPageToken;
                    result.PrevPageToken = response.PrevPageToken;
                    result.PageIndex = site.Pages.Count;

                    foreach (var item in response.Items)
                    {
                        var itemModel = new ItemModel()
                        {
                            Id = item.Id,
                            Title = item.Title,
                            Content = item.Content,
                            OriginalItem = item,
                            Parent = page
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
                    site.Pages.Add(result);
                }
            }
            catch (Exception ex)
            {
                err = ex;
            }

            callback(result, err);
        }

        public async void GetDataAlterInformation(string pageToken, Action<PageModel, Exception> callback)
        {
            HttpClient client = new HttpClient();
            string uri = "http://alterinformation.wordpress.com/feed/?paged=" + pageToken;

            Exception err = null;
            var result = new PageModel();
            
            try
            {
                var blog = await client.GetStringAsync("http://ajax.googleapis.com/ajax/services/feed/load?v=1.0&num=10&q=" + uri);
                var responseRootObject = JsonConvert.DeserializeObject<RootObject>(blog);

                SiteModel site = Sites.FirstOrDefault(x => x.Title == "Alter Information");
                if (site == null)
                {
                    site = new SiteModel()
                    {
                        Title = "Alter Information",
                        //Id = blog.Id
                    };

                    //group.ImagePath = blog.
                    Sites.Add(site);
                }

                PageModel page = site.Pages.FirstOrDefault(x => x.CurrentPageToken == pageToken.ToString());
                if (page != null)
                {
                    result = page;
                }
                else
                {
                    result.PageIndex = site.Pages.Count;
                    result.CurrentPageToken = Convert.ToInt16(result.PageIndex + 1).ToString();
                    result.NextPageToken = Convert.ToInt16(result.CurrentPageToken + 1).ToString();
                    foreach (var item in responseRootObject.responseData.feed.entries)
                    {
                        var itemModel = new ItemModel()
                        {
                            Title = item.title,
                            Content = item.content,
                            OriginalItem = item,
                            Parent = page
                        };

                        var document = new HtmlDocument();
                        document.LoadHtml(item.content);
                        var img = document.DocumentNode.Descendants().FirstOrDefault(doc => doc.Name == "img");
                        if (img != null)
                        {
                            itemModel.ImagePath = img.Attributes["src"].Value;
                        }

                        result.Items.Add(itemModel);
                    }
                    site.Pages.Add(result);
                }
            }
            catch (Exception ex)
            {
                err = ex;
            }

            callback(result, err);
        }

        public static async Task<SiteModel> GetSiteAsync(string siteId)
        {
            var matches = Sites.FirstOrDefault(x => x.Id == siteId);
            return matches;
        }

        public static async Task<PageModel> GetPageAsync(int pageIndex)
        {
            var matches = Sites.SelectMany(s => s.Pages).FirstOrDefault(x => x.PageIndex == pageIndex);
            return matches;
        }

        public static async Task<ItemModel> GetItemAsync(string itemId)
        {
            var matches = Sites.SelectMany(group => group.Pages).SelectMany(p => p.Items).FirstOrDefault(x => x.Id == itemId);
            return matches;
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
        */

        private static Task<string> MakeAsyncRequest(string url)
        {
            var request = WebRequest.CreateHttp(url);
            request.Method = "GET";

            var task = Task.Factory.FromAsync(request.BeginGetResponse,
                (asyncResult) => request.EndGetResponse(asyncResult),
                (object)null);

            return task.ContinueWith(t => ReadStreamFromResponse(t.Result));
        }

        private static string ReadStreamFromResponse(WebResponse response)
        {
            using (var responseStream = response.GetResponseStream())
            using (var sr = new StreamReader(responseStream))
            {
                var strContent = sr.ReadToEnd();
                return strContent;
            }
        }
         
    }
}
