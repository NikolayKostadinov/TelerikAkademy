using System;
using System.Collections.Generic;

namespace Musicstore.Server.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Album> Albums { get; set; }
        public ICollection<Song> Songs { get; set; }

        public Artist()
        {
            Albums = new HashSet<Album>();
            Songs = new HashSet<Song>();
        }
    }
}
