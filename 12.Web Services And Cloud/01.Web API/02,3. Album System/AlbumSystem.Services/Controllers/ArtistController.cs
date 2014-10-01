using AlbumSystem.Data;
using AlbumSystem.Models;
using AlbumSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlbumSystem.Services.Controllers
{
    public class ArtistController : ApiController
    {
        private IAlbumSystemData data;

        public ArtistController()
            : this(new AlbumSystemData())
        {
        }

        public ArtistController(IAlbumSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get(int id)
        {
            var artist = this.data.Artist.SelectAll().FirstOrDefault(a => a.Id == id);

            return Ok(artist);
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var artists = this.data.Artist.SelectAll().ToList();

            return Ok(artists);
        }

        [HttpPost]
        public IHttpActionResult Create(ArtistModel artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.data.Artist.Add(new Artist
            {
                Name = artist.Name,
                Country = artist.Country,
                DateOfBirth = artist.DateOfBirth

            });

            this.data.SaveChanges();

            return Ok(HttpStatusCode.Created);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, ArtistModel artist)
        {
            var existingArtist = this.data.Artist.SelectAll().FirstOrDefault(a => a.Id == id);

            if (existingArtist == null)
            {
                return BadRequest("No such artist with this id!");
            }

            existingArtist.Name = (artist.Name != null) ? artist.Name : existingArtist.Name;
            existingArtist.Country = (artist.Country != null) ? artist.Country : existingArtist.Country;
            existingArtist.DateOfBirth = (artist.DateOfBirth.Date == default(DateTime)) ? existingArtist.DateOfBirth : artist.DateOfBirth;

            this.data.Artist.Update(existingArtist);
            this.data.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var artist = this.data.Artist.SelectAll().FirstOrDefault(a => a.Id == id);

            if (artist == null)
            {
                return BadRequest("No such artist with this id!");
            }
            this.data.Artist.Delete(artist);

            this.data.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }
    }
}
