using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumSystem.Models
{
    public class Artist
    {
        private ICollection<Song> songs;
        private ICollection<Album> albums;

        public Artist()
        {
            this.songs = new HashSet<Song>();
            this.albums = new HashSet<Album>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}
