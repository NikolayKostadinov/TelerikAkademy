using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Musicstore.Server.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Producer { get; set; }

        [IgnoreDataMember]
        public ICollection<Artist> Artists { get; set; }
        [IgnoreDataMember]
        public ICollection<Song> Songs { get; set; }

        public Album() 
        {
            Artists = new HashSet<Artist>();
            Songs = new HashSet<Song>();
        }
    }
}
