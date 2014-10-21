using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WebAPI.Models
{
    public class ScoresDataModel
    {
        public static Expression<Func<Score, ScoresDataModel>> FromScore
        {
            get
            {
                return s => new ScoresDataModel
                {
                    Username = s.ScoreUserName,
                    Rank = s.Rank
                };
            }
        }
        public string Username { get; set; }

        public int Rank { get; set; }
    }
}