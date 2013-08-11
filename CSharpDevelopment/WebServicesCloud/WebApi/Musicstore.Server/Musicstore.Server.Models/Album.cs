using System.Collections.Generic;
using System.Runtime.Serialization;
using Musicstore.Server.Core;

namespace Musicstore.Server.Models
{
    public class Album: BaseEntity
    {
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
