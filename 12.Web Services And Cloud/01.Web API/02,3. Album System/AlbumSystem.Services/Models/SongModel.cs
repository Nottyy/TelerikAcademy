using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlbumSystem.Services.Models
{
    public class SongModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Range(1990, 2014)]
        public int Year { get; set; }

        public string Genre { get; set; }
    }
}