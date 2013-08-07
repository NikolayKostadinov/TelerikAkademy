using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Musicstore.Server.Models;
using Musicstore.Server.Data;
using WebGrease.Css.Extensions;

namespace Musicstore.Server.WebApi.Controllers
{
    public class AlbumController : ApiController
    {
        private MusicstoreContext db = new MusicstoreContext();

        // GET api/Album
        public IQueryable<Album> GetAlbums()
        {
            return db.Albums;
        }

        // GET api/Album/5
        public Album GetAlbum(int id)
        {
            Album album = db.Albums.Include("Artists").FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return album;
        }

        // PUT api/Album/5
        public HttpResponseMessage PutAlbum(int id, Album album)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != album.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            //var oldAlbum = db.Albums.FirstOrDefault(a => a.Id == album.Id);
            //if (oldAlbum != null)
            //{
            //    oldAlbum.Title = album.Title;
            //    oldAlbum.Year = album.Year;
            //    oldAlbum.Producer = album.Producer;
            //    CheckArtistsInAlbums(album);
            //    oldAlbum.Artists = album.Artists;
            //}

            CheckArtistsInAlbums(album);
            db.Entry(album).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, album);
        }

        // POST api/Album
        public HttpResponseMessage PostAlbum(Album album)
        {
            if (ModelState.IsValid)
            {
                CheckArtistsInAlbums(album);

                db.Albums.Add(album);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, album);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Album/5
        public HttpResponseMessage DeleteAlbum(int id)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Albums.Remove(album);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, album);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void CheckArtistsInAlbums(Album album)
        {
            var artists = new List<Artist>();
            album.Artists.ForEach(artist =>
            {
                var a = db.Artists.FirstOrDefault(x => x.Id == artist.Id);
                if (a == null)
                {
                    a = new Artist();
                    a.DateOfBirth = DateTime.Now;
                }
                artists.Add(a);
            });
            album.Artists = artists;
        }
    }
}