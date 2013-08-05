using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Musicstore.Data;
using Musicstore.Model;

namespace Musicstore.WebApp.Controllers
{
    public class ArtistController : ApiController
    {
        // GET api/values
        public IQueryable<Artist> Get()
        {
            return SessionState.db.Artists;
        }

        // GET api/values/5
        public Artist Get(int id)
        {
            return SessionState.db.Artists.FirstOrDefault(a => a.Id == id);
        }

        // POST api/values
        public void Post([FromBody]Artist value)
        {
            SessionState.db.Artists.Add(value);
            SessionState.db.SaveChanges();
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]Artist value)
        {
            return CheckId(id, a =>
            {
                a.Name = value.Name;
                a.Country = value.Country;
                a.DateOfBirth = value.DateOfBirth;
                SessionState.db.SaveChanges();
            });
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            return CheckId(id, a =>
            {
                SessionState.db.Artists.Remove(a);
                SessionState.db.SaveChanges();
            });
        }

        private HttpResponseMessage CheckId(int id, Action<Artist> action)
        {
            var artist = SessionState.db.Artists.FirstOrDefault(a => a.Id == id);
            if (artist == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound,
                "Artist with id: " + id + " was not found.");
            }

            if (action != null)
            {
                action(artist);
            }

            return new HttpResponseMessage();
        }
    }
}