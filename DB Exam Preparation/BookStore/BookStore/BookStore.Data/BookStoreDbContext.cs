namespace BookStore.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BookStore.Models;
    using BookStore.Data.Migrations;

    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext() : base("BookStoreConncetion")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreDbContext, Configuration>());
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Review> Review { get; set; }

        public IDbSet<Author> Authors { get; set; }
    }
}
