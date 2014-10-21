using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WebAPI.Models
{
    public class GameDataModel
    {
        public static Expression<Func<Game, GameDataModel>> FromGame
        {
            get
            {
                return g => new GameDataModel
                {
                    ID = g.ID,
                    Name = g.Name,
                    Blue = g.Blue != null ? g.Blue.Email : "No blue player yet",
                    Red = g.Red != null ? g.Red.Email : "No red player yet",
                    GameState = g.GameState,
                    DateCreated = g.DateCreated
                };
            }
        }
        public int ID { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }

    }
}