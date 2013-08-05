using System.Collections.Generic;

namespace Musicstore.Model
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

        public ICollection<Album> Albums { get; set; }

        public Song()
        {
            Albums = new HashSet<Album>();
        }
    }
}
