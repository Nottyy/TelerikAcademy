using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Game
    {
        private ICollection<Guess> guesses;
        private ICollection<Notification> notifications;
        public Game()
        {
            this.guesses = new HashSet<Guess>();
            this.notifications = new HashSet<Notification>();
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public string BlueId { get; set; }

        public virtual ApplicationUser Blue { get; set; }

        public string RedId { get; set; }

        public virtual ApplicationUser Red { get; set; }

        [Range(1000,9999)]
        public int RedNumber { get; set; }

        [Range(1000, 9999)]
        public int? BlueNumber { get; set; }

        public virtual ICollection<Guess> Guesses
        {
            get{ return this.guesses; }
            set { this.guesses = value; }
        }

        public virtual ICollection<Notification> Notifications
        {
            get { return this.notifications; }
            set { this.notifications = value; }
        }
        
    }
}
