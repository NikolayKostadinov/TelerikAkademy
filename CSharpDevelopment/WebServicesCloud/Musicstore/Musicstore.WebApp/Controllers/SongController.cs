using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Musicstore.Data;
using Musicstore.Model;

namespace Musicstore.WebApp.Controllers
{
    public class SongController : ApiController
    {
        // GET api/values
        public IQueryable<Song> Get()
        {
            return SessionState.db.Songs;
        }

        // GET api/values/5
        public Song Get(int id)
        {
            return SessionState.db.Songs.FirstOrDefault(a => a.Id == id);
        }

        // POST api/values
        public void Post([FromBody]Song value)
        {
            SessionState.db.Songs.Add(value);
            SessionState.db.SaveChanges();
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]Song value)
        {
            return CheckId(id, a =>
            {
                a.Title = value.Title;
                a.Year = value.Year;
                a.Genre = value.Genre;
                a.ArtistId = value.ArtistId;
                SessionState.db.SaveChanges();
            });
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            return CheckId(id, a =>
            {
                SessionState.db.Songs.Remove(a);
                SessionState.db.SaveChanges();
            });
        }

        private HttpResponseMessage CheckId(int id, Action<Song> action)
        {
            var song = SessionState.db.Songs.FirstOrDefault(a => a.Id == id);
            if (song == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound,
                "Song with id: " + id + " was not found.");
            }

            if (action != null)
            {
                action(song);
            }

            return new HttpResponseMessage();
        }
    }
}