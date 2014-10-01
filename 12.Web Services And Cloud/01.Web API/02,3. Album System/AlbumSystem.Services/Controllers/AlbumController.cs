namespace AlbumSystem.Services.Controllers
{
    using AlbumSystem.Data;
    using AlbumSystem.Models;
    using AlbumSystem.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;


    public class AlbumController : ApiController
    {
        private IAlbumSystemData data;
        

        public AlbumController()
            : this(new AlbumSystemData())
        {
        }

        public AlbumController(IAlbumSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get(int id)
        {
            var album = this.data.Albums.SelectAll().FirstOrDefault(a => a.Id == id);

            return Ok(album);
        }


        [HttpGet]
        public IHttpActionResult All()
        {
            var albums = this.data.Albums.SelectAll().ToList();

            return Ok(albums);
        }

        [HttpPost]

        public IHttpActionResult Create(AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest("Invalid album parameters!");
            }

            var newAlbum = new Album
            {
                Title = album.Title,
                Producer = album.Producer,
                Year = album.Year
            };

            this.data.Albums.Add(newAlbum);
            this.data.SaveChanges();

            return Ok(HttpStatusCode.Created);
        }

        [HttpPut]
        public IHttpActionResult AddSong(int albumId, int songId)
        {
            var song = this.data.Songs.SelectAll().FirstOrDefault(s => s.Id == songId);
            var album = this.data.Albums.SelectAll().FirstOrDefault(a => a.Id == albumId);

            if (song == null)
            {
                return BadRequest("Song does not exist!");
            }

            if (album == null)
            {
                return BadRequest("Album does not exist!");
            }

            if (album.Songs.Contains(song))
            {
                throw new ArgumentException("The album already has the song - {0}", song.Title);
            }

            album.Songs.Add(song);
            this.data.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }

        [HttpPut]
        public IHttpActionResult RemoveSong(int idAlbum, int idSong)
        {
            var existingSong = this.data.Songs.SelectAll().FirstOrDefault(a => a.Id == idSong);
            var existingAlbum = this.data.Albums.SelectAll().FirstOrDefault(a => a.Id == idAlbum);

            if (existingSong == null)
            {
                return BadRequest("There is not a song with this id!");
            }

            if (existingAlbum == null)
            {
                return BadRequest("There is not an album with this id!");
            }

            existingAlbum.Songs.Remove(existingSong);

            this.data.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }

        [HttpPut]
        public IHttpActionResult AddArtist(int idAlbum, int idArtist)
        {
            var artist = this.data.Artist.SelectAll().FirstOrDefault(a => a.Id == idArtist);
            var album = this.data.Albums.SelectAll().FirstOrDefault(a => a.Id == idAlbum);

            if (artist == null)
            {
                return BadRequest("There is not an artist with this id!");
            }

            if (album == null)
            {
                return BadRequest("There is not an album with this id!");
            }

            album.Artists.Add(artist);
            this.data.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }

        [HttpPut]
        public IHttpActionResult RemoveArtist(int idAlbum, int idArtist)
        {
            var artist = this.data.Artist.SelectAll().FirstOrDefault(a => a.Id == idArtist);
            var album = this.data.Albums.SelectAll().FirstOrDefault(a => a.Id == idAlbum);

            if (artist == null)
            {
                return BadRequest("There is not an artist with this id!");
            }

            if (album == null)
            {
                return BadRequest("There is not an album with this id!");
            }

            album.Artists.Remove(artist);
            this.data.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }

        [HttpPut]
        public IHttpActionResult Update(int albumId, SongModel song)
        {
            var album = this.data.Albums.SelectAll().FirstOrDefault(a => a.Id == albumId);
            var albumSong = album.Songs.FirstOrDefault(s => s.Id == song.Id);

            if (albumSong == null)
            {
                return BadRequest("The album does not have that song!");
            }

            albumSong.Genre = song.Genre;
            albumSong.Title = song.Title;
            albumSong.Year = song.Year;

            this.data.Songs.Update(albumSong);
            this.data.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var album = this.data.Albums.SelectAll().FirstOrDefault(a => a.Id == id);

            if (album == null)
            {
                return BadRequest("No such artist with this id!");
            }

            this.data.Albums.Delete(album);

            this.data.SaveChanges();

            return Ok(HttpStatusCode.OK);
        }
    }
}
