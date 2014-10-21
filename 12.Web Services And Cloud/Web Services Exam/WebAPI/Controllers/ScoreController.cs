using ExamData;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ScoreController : BaseApiController
    {
        public ScoreController()
            : this(new BullsAndCowsData(new BullsAndCowsDbContext()))
        {
        }

        public ScoreController(IBullsAndCowsData data)
            : base(data)
        {
            this.data = data;
        }

        public IHttpActionResult Get()
        {
            var scores = this.data.Scores.All()
                .OrderBy(s => s.Rank)
                .ThenBy(s => s.ScoreUserName)
                .Select(ScoresDataModel.FromScore);

            return Ok(scores);
        }

    }
}
