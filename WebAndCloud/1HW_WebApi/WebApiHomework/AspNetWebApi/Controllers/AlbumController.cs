using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CodeFirst.Models;
using CodeFirst.Data;

namespace AspNetWebApi.Controllers
{
    public class AlbumController : ApiController
    {
        private MusicStoreContext db = new MusicStoreContext();

        // GET api/Album
        public IEnumerable<Album> GetAlbums()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
            return db.Albums.AsEnumerable();
        }

        // GET api/Album/5
        public Album GetAlbum(int id)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return album;
        }

        // PUT api/Album/5
        public HttpResponseMessage PutAlbum(int id, Album album)
        {
            if (ModelState.IsValid && id == album.AlbumId)
            {
                db.Entry(album).State = EntityState.Modified;

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

        // POST api/Album
        public HttpResponseMessage PostAlbum(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, album);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = album.AlbumId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        //public HttpResponseMessage Post([FromBody]Album value)
        //{
        //    var album = value.CreateAlbum();
        //    this.db.Albums.Add(album);

        //    var message = this.Request.CreateResponse(HttpStatusCode.Created);
        //    message.Headers.Location = new Uri(this.Request.RequestUri + album.AlbumId.ToString(CultureInfo.InvariantCulture));
        //    return message;
        //}

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
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, album);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}