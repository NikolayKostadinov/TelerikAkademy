using System.Collections.Generic;

namespace Musicstore.Model
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Producer { get; set; }
        
        public ICollection<Artist> Artists { get; set; }
        public ICollection<Song> Songs { get; set; }

        public Album() 
        {
            Artists = new HashSet<Artist>();
            Songs = new HashSet<Song>();
        }
    }
}
