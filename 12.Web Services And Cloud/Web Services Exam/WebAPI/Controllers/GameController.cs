using ExamData;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

using Microsoft.AspNet.Identity;

namespace WebAPI.Controllers
{
    public class GamesController : BaseApiController
    {
        const string JOINED_GAME_MESSAGE = "You joined game {0}";
        const int DEFAULT_PAGE_SIZE = 10;
        private Random rand = new Random();


        public GamesController()
            : this(new BullsAndCowsData(new BullsAndCowsDbContext()))
        {
        }

        public GamesController(IBullsAndCowsData data)
            : base(data)
        {
            this.data = data;
        }

        public IHttpActionResult Get()
        {
            return Get(0);
        }

        public IHttpActionResult Get(int page)
        {
            var games = this.OrderGames(page)
                .Where(g => g.Blue == "No blue player yet")
                .Skip(page * DEFAULT_PAGE_SIZE)
                .Take(DEFAULT_PAGE_SIZE)
                .ToList();

            return Ok(games);
        }

        [Authorize]
        public IHttpActionResult GetByPage(int page)
        {
            var userId = this.User.Identity.GetUserId();
            var games = this.data.Games.All()
                .Where(g => g.GameState == GameState.WaitingForOpponent
                    || (g.GameState != GameState.WaitingForOpponent && (g.BlueId == userId || g.RedId == userId)))
                    .OrderBy(g => g.GameState)
                    .ThenBy(g => g.Name)
                    .ThenBy(g => g.DateCreated)
                    .ThenBy(g => g.Red.Email)
                    .Select(GameDataModel.FromGame);

            return Ok(games);
        }

        [Authorize]
        public IHttpActionResult GetId(int id)
        {
            var userId = this.User.Identity.GetUserId();

            var game = this.data.Games
                .All()
                .Where(g => g.ID == id)
                .Select(GameForUsernameDataModel.FromGame);

            return Ok(game);
        }

        [Authorize]
        public IHttpActionResult Post(PostRequestCreateGame model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid post parameters!");
            }

            ValidateNumber(model.Number);

            var userId = this.User.Identity.GetUserId();

            var game = new Game
            {
                Name = model.Name,
                RedNumber = model.Number,
                DateCreated = DateTime.Now,
                RedId = userId,
                GameState = GameState.WaitingForOpponent,
            };

            this.data.Games.Add(game);
            this.data.SaveChanges();

            var responseModel = this.data.Games.All().Where(g => g.ID == game.ID)
                .Select(GameDataModel.FromGame);

            return Ok(responseModel);
        }


        [Authorize]
        [HttpPut]
        public IHttpActionResult Put(int id, GetNumberDataModel model)
        {
            Validate(model.Number);

            var game = this.data.Games.Find(id);
            if (game == null)
            {
                return BadRequest("Invalid game id!");
            }

            var userId = this.User.Identity.GetUserId();

            if (userId == game.RedId)
            {
                return BadRequest("A game, created by a user, cannot be joined by the same user.");
            }

            game.BlueNumber = model.Number;
            game.BlueId = userId;

            var playerInTurn = rand.Next(1, 2);
            game.GameState = playerInTurn == 1 ? GameState.RedInTurn : GameState.BlueInTurn;

            var currentMessage = string.Format(JOINED_GAME_MESSAGE, game.Name);

            var notification = new Notification
            {
                DateCreated = DateTime.Now,
                GameId = game.ID,
                Type = NotificationType.YourTurn,
                State = NotificationState.Unread,
                Message = string.Format(currentMessage),
            };

            game.Notifications.Add(notification);
            this.data.Games.Update(game);

            var user = this.data.Users.Find(userId);

            user.Notifications.Add(notification);
            this.data.Users.Update(user);

            this.data.SaveChanges();

            return Ok(new
            {
                result = currentMessage
            });
        }

        private IEnumerable<GameDataModel> OrderGames(int page)
        {
            var games = this.data.Games
                .All()
                .OrderBy(g => g.GameState)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.Red.Email)
                .Select(GameDataModel.FromGame);


            return games;
        }

        private void ValidateNumber(int number)
        {
            if (number < 0 || number > 9999)
            {
                throw new ArgumentOutOfRangeException("Invalid number");
            }
        }
    }
}
