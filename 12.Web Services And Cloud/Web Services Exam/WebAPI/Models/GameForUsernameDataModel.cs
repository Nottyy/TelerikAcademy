using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WebAPI.Models
{
    public class GameForUsernameDataModel
    {
        private ICollection<Guess> guesses;

        public GameForUsernameDataModel()
        {
            this.guesses = new HashSet<Guess>();
        }

        public static Expression<Func<Game, GameForUsernameDataModel>> FromGame
        {
            get
            {

                return g => new GameForUsernameDataModel
                {
                    ID = g.ID,
                    Name = g.Name,
                    DateCreated = g.DateCreated,
                    Red = g.Red != null ? g.Red.Email : "No red player yet",
                    Blue = g.Blue != null ? g.Blue.Email : "No blue player yet",
                    //YourNumber =  ,
                    //YourGuesses = g.Guesses,
                    //YourColor = g ,
                    GameState = g.GameState
                };
            }
        }
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string Red { get; set; }

        public string Blue { get; set; }

        [Range(1000,9999)]
        public int YourNumber { get; set; }

        public virtual ICollection<Guess> YourGuesses
        {
            get { return this.guesses; }
            set { this.guesses = value; }
        }

       
        public string YourColor { get; set; }

        public GameState GameState { get; set; }

    }
}