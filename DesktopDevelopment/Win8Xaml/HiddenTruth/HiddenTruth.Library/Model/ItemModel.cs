using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Blogger.v3.Data;

namespace HiddenTruth.Library.Model
{
    public class ItemModel
    {
        public int GroupIndex { get; set; }

        public string ImagePath { get; set; }

        public string Title { get; set; }

        public Post Post { get; set; }
    }
}
