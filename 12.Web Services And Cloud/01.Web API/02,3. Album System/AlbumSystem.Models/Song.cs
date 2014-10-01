using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumSystem.Models
{
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Range(1990,2014)]
        public int Year { get; set; }

        public string Genre { get; set; }
        
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
