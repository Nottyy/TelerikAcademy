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
    public class GuessController : BaseApiController
    {
        const string YOUR_TURN_MESSAGE = "It is your turn in game {0}";
        const string BEATEN_MESSAGE = "{0} beat you in game {1}";
        const string YOU_WON_MESSAGE = "You beat {0} in game {1}";

        public GuessController()
            : this(new BullsAndCowsData(new BullsAndCowsDbContext()))
        {
        }

        public GuessController(IBullsAndCowsData data)
            : base(data)
        {
            this.data = data;
        }

        [Authorize]
        public IHttpActionResult Post(int id, [FromBody]GetNumberDataModel model)
        {
            var game = this.data.Games.Find(id);
            if (game == null)
            {
                return BadRequest("Invalid game id!");
            }
            if (game.GameState == GameState.WaitingForOpponent || game.GameState == GameState.Finished)
            {
                return BadRequest("Invalid game state");
            }

            var userId = this.User.Identity.GetUserId();
            if (!(game.BlueId == userId || game.RedId == userId))
            {
                return BadRequest("Wrong user!");
            }

            ApplicationUser playerInTurn;
            ApplicationUser otherPlayer;
            int originalNumber = int.MinValue; ;

            if (game.RedId == userId && game.GameState == GameState.RedInTurn)
            {
                otherPlayer = game.Blue;
                playerInTurn = game.Red;
                originalNumber = game.RedNumber;
            }
            else
            {
                otherPlayer = game.Red;
                playerInTurn = game.Blue;
                originalNumber = (int)game.BlueNumber;
            }
            
            ValidateNumber(model.Number);

            var bullsAndCowsCheck = CheckBullsAndCows(model.Number.ToString(), originalNumber.ToString());
            var bulls = bullsAndCowsCheck[0];
            var cows = bullsAndCowsCheck[1];

            var toOtherPlayerNotification = new Notification
            {
                DateCreated = DateTime.Now,
                GameId = game.ID,
                State = NotificationState.Unread,
                UserId = otherPlayer.Id
            };

            if (bulls == 4)
            {
                game.GameState = GameState.Finished;
                toOtherPlayerNotification.Message = string.Format(BEATEN_MESSAGE, playerInTurn.Email,game.Name);
                toOtherPlayerNotification.Type = NotificationType.GameLost;

                var toCurrentPlayerMessage = new Notification
                {
                    DateCreated = DateTime.Now,
                    GameId = game.ID,
                    State = NotificationState.Unread,
                    Type = NotificationType.GameWon,
                    Message = string.Format(YOU_WON_MESSAGE, otherPlayer.Email, game.Name),
                    UserId = playerInTurn.Id
                };

                this.data.Notifications.Add(toCurrentPlayerMessage);
            }
            else
            {
                toOtherPlayerNotification.Message = string.Format(YOUR_TURN_MESSAGE, game.Name);
                toOtherPlayerNotification.Type = NotificationType.YourTurn;
            }

            this.data.Notifications.Add(toOtherPlayerNotification);

            var guess = new Guess
            {
                BullsCount = bulls,
                CowsCount = cows,
                DateMade = DateTime.Now,
                GameID = game.ID,
                Number = model.Number,
                UserID = userId
            };

            this.data.Guesses.Add(guess);

            var response = this.data.Guesses.All().Where(g => g.ID == guess.ID).Select(GuessDataModel.FromGame);

            this.data.Games.Update(game);
            this.data.SaveChanges();

            return Ok(response);
        }

        private List<int> CheckBullsAndCows(string number, string original)
        {
            int bulls = 0;
            int cows = 0;

            var added = new HashSet<int>();

            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == original[i])
                {
                    bulls++;
                    added.Add(int.Parse(i.ToString()));
                }
            }

            for (int i = 0; i < number.Length; i++)
            {
                if (!added.Contains(i))
                {
                    for (int j = 0; j < number.Length; j++)
                    {
                        if (i != j && !added.Contains(j))
                        {
                            if (number[j] == original[i])
                            {
                                added.Add(j);
                                cows++;
                            }
                        }
                    }
                }
            }

            var result = new List<int>();
            result.Add(bulls);
            result.Add(cows);

            return result;
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
