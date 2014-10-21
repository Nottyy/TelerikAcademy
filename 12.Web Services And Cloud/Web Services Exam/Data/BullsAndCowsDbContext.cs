using ExamData.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamData
{
    public class BullsAndCowsDbContext : IdentityDbContext<ApplicationUser>
    {
        public BullsAndCowsDbContext()
            : base("BullsAndCowsDb", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext, Configuration>());
        }

        public static BullsAndCowsDbContext Create()
        {
            return new BullsAndCowsDbContext();
        }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Notification> Notifications { get; set; }

        public IDbSet<Score> Scores { get; set; }

        public IDbSet<Guess> Guesses { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    // Configure Code First to ignore PluralizingTableName convention 
        //    // If you keep this convention then the generated tables will have pluralized names. 
        //    modelBuilder.Entity<ApplicationUser>()
        //    .HasOptional(f => f.Score)
        //    .WithRequired(s => s.User);
        //}
    }
}
