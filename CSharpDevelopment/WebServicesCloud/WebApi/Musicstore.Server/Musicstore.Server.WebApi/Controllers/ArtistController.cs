using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
    public class ArtistController : ApiController
    {
        // GET api/Artist
        public IQueryable<Artist> GetArtists()
        {
            return db.Artists;
        }

        // GET api/Artist/5
        public Artist GetArtist(int id)
        {
            Artist artist = db.Artists.Include("Albums").FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return artist;
        }

        // PUT api/Artist/5
        public HttpResponseMessage PutArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != artist.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            CheckAlbumsInArtist(artist);
            db.Entry(artist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        // POST api/Artist
        public HttpResponseMessage PostArtist(Artist artist)
        {
            if (ModelState.IsValid)
            {
                CheckAlbumsInArtist(artist);

                db.Artists.Add(artist);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, artist);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Artist/5
        public HttpResponseMessage DeleteArtist(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Artists.Remove(artist);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void CheckAlbumsInArtist(Artist artist)
        {
            var artists = new List<Album>();
            artist.Albums.ForEach(album =>
            {
                var a = db.Albums.FirstOrDefault(x => x.Id == album.Id);
                if (a == null)
                {
                    a = new Album();
                }
                artists.Add(a);
            });
            artist.Albums = artists;
        }
    }
}