using System.Collections.Generic;

namespace HiddenTruth.Library.Model.AlterInformation
{
    public class Entry
    {
        public List<MediaGroup> mediaGroups { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string author { get; set; }
        public string publishedDate { get; set; }
        public string contentSnippet { get; set; }
        public string content { get; set; }
        public List<string> categories { get; set; }
    }
}