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
using CodeFirst.Models;
using CodeFirst.Data;

namespace AspNetWebApi.Controllers
{
    public class ArtistController : ApiController
    {
        private MusicStoreContext db = new MusicStoreContext();

        // GET api/Artist
        public IEnumerable<Artist> GetArtists()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
            return db.Artists.AsEnumerable();
        }

        // GET api/Artist/5
        public Artist GetArtist(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return artist;
        }

        // PUT api/Artist/5
        public HttpResponseMessage PutArtist(int id, [FromBody]Artist artist)
        {
            if (ModelState.IsValid)//&& id == artist.ArtistId)
            {
                Artist artistToUpdate = db.Artists.Find(id);

                //please tell me how to do this in a better way :D
                artistToUpdate.BirthDate = artist.BirthDate;
                artistToUpdate.Name = artist.Name;
                artistToUpdate.Country = artist.Country;
            //    artistToUpdate.Albums = artist.Albums;

                db.Entry(artistToUpdate).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Artist
        public HttpResponseMessage PostArtist(Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, artist);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = artist.ArtistId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
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
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}