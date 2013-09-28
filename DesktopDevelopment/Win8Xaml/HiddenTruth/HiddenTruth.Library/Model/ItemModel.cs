using System;

namespace HiddenTruth.Library.Model
{
    public class ItemModel
    {
        public string Id { get; set; }

        public string ImagePath { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string OriginalUrl { get; set; }

        public dynamic OriginalItem { get; set; }

        public PageModel Parent { get; set; }

        public ItemModel()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}
