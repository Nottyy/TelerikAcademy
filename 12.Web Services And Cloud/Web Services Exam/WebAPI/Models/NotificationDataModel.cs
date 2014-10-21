using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WebAPI.Models
{
    public class NotificationDataModel
    {
        public static Expression<Func<Notification, NotificationDataModel>> FromNotification
        {
            get
            {
                return g => new NotificationDataModel
                {
                    Id = g.Id,
                    Message = g.Message,
                    DateCreated = g.DateCreated,
                    Type = g.Type,
                    State = g.State,
                    GameId = g.GameId
                };
            }
        }

        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public NotificationType Type { get; set; }

        public NotificationState State { get; set; }

        public int GameId { get; set; }
    }
}