using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class PostRequestCreateGame
    {
        public string Name { get; set; }

        [Range(1000,9999)]
        public int Number { get; set; }

    }
}