using ExamData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using WebAPI.Models;
using Models;

namespace WebAPI.Controllers
{
    public class NotificationsController : BaseApiController
    {
        const int DEFAULT_PAGE_SIZE = 10;

        public NotificationsController()
            : this(new BullsAndCowsData(new BullsAndCowsDbContext()))
        {
        }

        public NotificationsController(IBullsAndCowsData data)
            : base(data)
        {
            this.data = data;
        }


        [Authorize]
        public IHttpActionResult Get(int? page)
        {
            var userId = this.User.Identity.GetUserId();
            var currentUser = this.data.Users.Find(userId);

            if (currentUser == null)
            {
                return BadRequest("Invalid user!");
            }

            int pageSkipped = 0;
            if (page != null)
            {
                pageSkipped = (int)page;
            }

            var usersNotifications = currentUser
                                .Notifications.AsQueryable()
                                .OrderByDescending(n => n.DateCreated)
                                .Skip(pageSkipped * DEFAULT_PAGE_SIZE)
                                .Take(DEFAULT_PAGE_SIZE)
                                .Select(NotificationDataModel.FromNotification);

            return Ok(usersNotifications);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult next()
        {
            var userId = this.User.Identity.GetUserId();
            var currentUser = this.data.Users.Find(userId);

            if (currentUser == null)
            {
                return BadRequest("Invalid user!");
            }

            var usersNotifications = currentUser
                                .Notifications.AsQueryable()
                                .Where(n => n.State == NotificationState.Unread)
                                .OrderBy(n => n.DateCreated)
                                .Take(1)
                                .Select(NotificationDataModel.FromNotification);
            if (usersNotifications.Count() == 0)
            {
                //return NotFound(HttpStatusCode.NotModified);
            }

            return Ok(usersNotifications);
        }

    }
}
