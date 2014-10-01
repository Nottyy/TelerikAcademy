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
    public class SongController : ApiController
    {
        private IAlbumSystemData data;

        public SongController()
            : this(new AlbumSystemData())
        {
        }

        public SongController(IAlbumSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get(int id)
        {
            var song = this.data.Songs.SelectAll().FirstOrDefault(a => a.Id == id);

            return Ok(song);
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var songs = this.data.Songs.SelectAll().ToList();

            return Ok(songs);
        }

        [HttpPost]
        public IHttpActionResult Create(SongModel song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artistOfSong = this.data.Artist.SelectAll().FirstOrDefault(a => a.Id == song.Id);

            if (artistOfSong == null)
            {
                return BadRequest("Can not find artist by given id!");
            }
            this.data.Songs.Add(new Song
            {
                Title = song.Title,
                Genre = song.Genre,
                Year = song.Year,
                ArtistId = artistOfSong.Id

            });

            this.data.SaveChanges();

            return Ok(HttpStatusCode.Created);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, SongModel song)
        {
            var existingSong = this.data.Songs.SelectAll().FirstOrDefault(a => a.Id == id);

            if (existingSong == null)
            {
                return BadRequest("No such song with this id!");
            }

            existingSong.Title = (song.Title != null) ? song.Title : existingSong.Title;
            existingSong.Genre = (song.Genre != null) ? song.Genre : existingSong.Genre;
            existingSong.Year = (song.Year != 0) ? song.Year : existingSong.Year;

            this.data.Songs.Update(existingSong);
            this.data.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var song = this.data.Songs.SelectAll().FirstOrDefault(a => a.Id == id);

            if (song == null)
            {
                return BadRequest("No such artist with this id!");
            }
            this.data.Songs.Delete(song);

            this.data.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }
    }
}
