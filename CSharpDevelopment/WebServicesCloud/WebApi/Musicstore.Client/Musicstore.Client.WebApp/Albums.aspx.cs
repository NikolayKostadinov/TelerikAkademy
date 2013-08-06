using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Musicstore.Server.Models;

namespace Musicstore.Client.WebApp
{
    public partial class Albums : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData.ddlArtistsFill(lbArtists);
            LoadData.ddlSongsFill(lbSongs);
            grdAlbumsFill();
        }

        private void grdAlbumsFill()
        {
            var response = SessionState.Client.GetAsync("api/album").Result;
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<Album>>().Result;
                grdAlbums.DataSource = albums;
                grdAlbums.DataBind();
            }
        }

        protected void btnAlbumSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAlbumTitle.Text))
            {
                var album = new Album();
                album.Title = txtAlbumTitle.Text;

                int year = 0;
                if (int.TryParse(txtAlbumYear.Text, out year))
                {
                    album.Year = year;
                }

                hfArtists.Value.Split(',').ToList().ForEach(item =>
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        var artist = SessionState.Artists.FirstOrDefault(a => a.Id == int.Parse(item.Split(';')[0]));
                        if (artist == null)
                        {
                            artist = new Artist()
                            {
                                Name = item.Split(';')[1]
                            };
                        }
                        album.Artists.Add(artist);
                    }
                });

                //hfSongs.Value.Split(',').ToList().ForEach(item =>
                //{
                //    if (!string.IsNullOrEmpty(item))
                //    {
                //        var artist = SessionState.Artists.FirstOrDefault(a => a.Id == int.Parse(item.Split(';')[0]));
                //        if (artist == null)
                //        {
                //            artist = new Artist()
                //            {
                //                Name = item.Split(';')[1]
                //            };
                //        }
                //        album.Artists.Add(artist);
                //    }
                //});

                album.Producer = txtAlbumProducer.Text;

                var response = SessionState.Client.PostAsJsonAsync("api/album", album).Result;
                if (response.IsSuccessStatusCode)
                {
                    var a = response.Content.ReadAsAsync<HttpResponseMessage>().Result;
                }
            }
        }
    }
}