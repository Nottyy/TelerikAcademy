using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WebAPI.Models
{
    public class GuessDataModel
    {
        public static Expression<Func<Guess, GuessDataModel>> FromGame
        {
            get
            {
                return g => new GuessDataModel
                {
                    Id = g.ID,
                    UserID = g.User.Id,
                    Username = g.User.Email,
                    GameId = g.GameID,
                    Number = g.Number,
                    DateMade = g.DateMade,
                    CowsCount = g.CowsCount,
                    BullsCount = g.BullsCount
                };
            }
        }
        public int Id { get; set; }

        public string UserID { get; set; }

        public string Username { get; set; }
        public int GameId { get; set; }

        [Range(1000,9999)]
        public int Number { get; set; }
            
        public DateTime DateMade { get; set; }

        [Range(0,4)]
        public int CowsCount { get; set; }

        [Range(0,4)]
        public int BullsCount { get; set; }

    }
}