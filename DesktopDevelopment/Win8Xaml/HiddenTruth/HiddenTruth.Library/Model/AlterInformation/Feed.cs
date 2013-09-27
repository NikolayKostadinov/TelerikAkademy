using System.Collections.Generic;

namespace HiddenTruth.Library.Model.AlterInformation
{
    public class Feed
    {
        public string feedUrl { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public List<Entry> entries { get; set; }
    }
}