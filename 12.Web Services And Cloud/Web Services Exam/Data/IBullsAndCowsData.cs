using ExamData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ExamData
{
    public interface IBullsAndCowsData
    {
        IRepository<Game> Games { get; }

        IRepository<Guess> Guesses { get; }

        IRepository<Notification> Notifications { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<Score> Scores { get; }

        void SaveChanges();
    }
}
