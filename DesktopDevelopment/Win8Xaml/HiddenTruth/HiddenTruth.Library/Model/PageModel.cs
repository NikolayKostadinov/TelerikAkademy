using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HiddenTruth.Library.Model
{
    public class PageModel
    {
        public int PageIndex { get; set; }

        public string CurrentPageToken { get; set; }

        public string NextPageToken { get; set; }

        public string PrevPageToken { get; set; }

        public ObservableCollection<ItemModel> Items { get; set; }

        public PageModel()
        {
            Items = new ObservableCollection<ItemModel>();
        }
    }
}
