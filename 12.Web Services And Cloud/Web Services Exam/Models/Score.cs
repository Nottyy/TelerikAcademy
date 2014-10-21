using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Score
    {
        public Score()
        {
            this.Users = new HashSet<ApplicationUser>();
        }
        public int ID { get; set; }

        public string ScoreUserName { get; set; }

        public int Rank { get; set; }

        public int WinsCount { get; set; }

        public int LossesCount { get; set; }

        public string UserID { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
