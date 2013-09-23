using System.Collections.Generic;
using Google.Apis.Blogger.v3.Data;

namespace HiddenTruth.Library.Model
{
    public class PageModel
    {
        public IList<ItemModel> Items { get; set; }

        public string CurrentPageToken { get; set; }

        public string NextPageToken { get; set; }

        public string PrevPageToken { get; set; }

        public PageModel()
        {
            Items = new List<ItemModel>();
        }
    }
}
