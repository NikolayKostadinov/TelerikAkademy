using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Musicstore.Data;
using Musicstore.Model;

namespace Musicstore.Console
{
    class Program
    {
        static void Main()
        {
            //AddNewAlbum();
            ListAlbums();
        }

        private static void AddNewAlbum()
        {
            Album album = new Album();
            album.Title = "test 3";
            album.Artists.Add(new Artist()
            {
                Name = "art 3",
                Country = "BG",
                DateOfBirth = DateTime.Now
            });
            var response = SessionState.Client.PostAsJsonAsync("album", album).Result;
            if (response.IsSuccessStatusCode)
            {
                var a = response.Content.ReadAsAsync<Artist>().Result;
                System.Console.WriteLine(a.Id);
            }
            else
            {
                System.Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void ListAlbums()
        {
            var response = SessionState.Client.GetAsync("album").Result;
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<Album>>().Result;
                foreach (var album in albums)
                {
                    System.Console.WriteLine(album.Id);
                }
            }
        }
    }
}
