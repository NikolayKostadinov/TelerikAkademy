using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Musicstore.Server.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }

        [IgnoreDataMember]
        public ICollection<Album> Albums { get; set; }
        [IgnoreDataMember]
        public ICollection<Song> Songs { get; set; }

        public Artist()
        {
            Albums = new HashSet<Album>();
            Songs = new HashSet<Song>();
        }
    }
}
