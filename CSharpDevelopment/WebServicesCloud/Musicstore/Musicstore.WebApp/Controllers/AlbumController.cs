using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Musicstore.Data;
using Musicstore.Model;

namespace Musicstore.WebApp.Controllers
{
    public class AlbumController : ApiController
    {
        // GET api/values
        public IQueryable<Album> Get()
        {
            return SessionState.db.Albums.Include("Artists");
        }

        // GET api/values/5
        public Album Get(int id)
        {
            return SessionState.db.Albums.FirstOrDefault(a => a.Id == id);
        }

        // POST api/values
        public Album Post([FromBody]Album value)
        {
            SessionState.db.Albums.Add(value);
            SessionState.db.SaveChanges();
            return value;
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]Album value)
        {
            return CheckId(id, a =>
            {
                a.Title = value.Title;
                a.Year = value.Year;
                a.Producer = value.Producer;
                SessionState.db.SaveChanges();
            });
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            return CheckId(id, a =>
            {
                SessionState.db.Albums.Remove(a);
                SessionState.db.SaveChanges();
            });
        }

        private HttpResponseMessage CheckId(int id, Action<Album> action)
        {
            var album = SessionState.db.Albums.FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound,
                "Album with id: " + id + " was not found.");
            }

            if (action != null)
            {
                action(album);
            }

            return new HttpResponseMessage();
        }
    }
}