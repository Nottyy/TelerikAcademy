using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Guess
    {
        public int ID { get; set; }

        public string UserID { get; set; }

        public ApplicationUser User { get; set; }
        public int GameID { get; set; }

        public virtual Game Game { get; set; }

        [Range(1000,9999)]
        public int Number { get; set; }
            
        public DateTime DateMade { get; set; }

        [Range(0,4)]
        public int CowsCount { get; set; }

        [Range(0,4)]
        public int BullsCount { get; set; }
    }
}
