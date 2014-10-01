namespace BookStore.Importer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BookStore.Data;
    using BookStore.Models;
    using System.Xml.Linq;

    public class Program
    {
        public static BookStoreDbContext db;
        static void Main()
        {
            db = new BookStoreDbContext();

            //ImportXmlData();
            SearchXmlData();
        }

        private static void SearchXmlData()
        {
            var reviewsQueries = db.Review.AsQueryable();
            var queries = XElement.Load(@"..\..\reviews-queries.xml");
            var searchResults = new XElement("search-results");

            foreach (var xmlQuery in queries.Elements())
            {
                if (xmlQuery.Attribute("type").Value == "by-period")
                {
                    DateTime startDate = DateTime.Parse(xmlQuery.Element("start-date").Value);
                    DateTime endDate = DateTime.Parse(xmlQuery.Element("end-date").Value);
                    //var s = reviewsQueries.Where(r => r.CreatedOn >= startDate && r.CreatedOn <= endDate).ToList();
                    reviewsQueries = reviewsQueries.Where(r => r.CreatedOn >= startDate && r.CreatedOn <= endDate);
                }
                else if (xmlQuery.Attribute("type").Value == "by-author")
                {
                    var authorName = xmlQuery.Element("author-name").Value;

                    reviewsQueries = reviewsQueries.Where(r => r.Author.Name == authorName);
                }

                var resultSet = reviewsQueries
                    .OrderBy(r => r.CreatedOn)
                    .ThenBy(r => r.Content).ToList()
                    .Select(rev =>
                    new
                    {
                        Date = rev.CreatedOn,
                        Content = rev.Content,
                        Book = new
                        {
                            Title = rev.Book.Title,
                            Authors = rev.Book.Authors.AsQueryable()
                                .OrderBy(a => a.Name) 
                                .Select(a => a.Name),
                            ISBN = rev.Book.ISBN,
                            URL = rev.Book.Website
                        }
                    }).ToList();

                var resultSetElement = new XElement("result-set");

                foreach (var resultInResultSet in resultSet)
                {
                    var review = new XElement("review");
                    review.Add(new XElement("date", resultInResultSet.Date.ToString("d-MMM-yyyy")));
                    review.Add(new XElement("content", resultInResultSet.Content));

                    var book = new XElement("book");
                    book.Add(new XElement("title", resultInResultSet.Book.Title));

                    if (resultInResultSet.Book.Authors.Count() > 0)
                    {
                        book.Add(new XElement("authors", string.Join(", ", resultInResultSet.Book.Authors)));
                    }
                    if (resultInResultSet.Book.ISBN != null)
                    {
                        book.Add(new XElement("isbn", resultInResultSet.Book.ISBN));
                    }

                    if (resultInResultSet.Book.URL != null)
                    {
                        book.Add(new XElement("url", resultInResultSet.Book.URL));
                    }

                    review.Add(book);

                    resultSetElement.Add(review);
                }

                searchResults.Add(resultSetElement);
            }

            searchResults.Save(@"..\..\reviews-search-results.xml");
        }

        private static void ImportXmlData()
        {
            var xmlBooks = XElement.Load(@"..\..\complex-search.xml");

            foreach (var xmlBook in xmlBooks.Elements("book"))
            {
                var currentBook = new Book();
                currentBook.Title = xmlBook.Element("title").Value;

                var isbn = xmlBook.Element("isbn");
                if (isbn != null)
                {
                    currentBook.ISBN = isbn.Value;
                }

                var price = xmlBook.Element("price");
                if (price != null)
                {
                    currentBook.Price = decimal.Parse(price.Value);
                }

                var webSite = xmlBook.Element("web-site");
                if (webSite != null)
                {
                    currentBook.Website = webSite.Value;
                }

                var xmlAuthors = xmlBook.Element("authors");
                if (xmlAuthors != null)
                {
                    foreach (var xmlAuthor in xmlAuthors.Elements("author"))
                    {
                        var authorName = xmlAuthor.Value;
                        var author = GetAuthor(authorName);

                        currentBook.Authors.Add(author);
                    }
                }

                var xmlReviews = xmlBook.Element("reviews");
                if (xmlReviews != null)
                {
                    foreach (var xmlReview in xmlReviews.Elements("review"))
                    {
                        var reviewDate = xmlReview.Attribute("date");
                        var author = xmlReview.Attribute("author");
                        var review = new Review
                        {
                            Content = xmlReview.Value,
                            CreatedOn = reviewDate == null ? DateTime.Now : DateTime.Parse(reviewDate.Value),
                        };

                        if (author != null)
                        {
                            review.Author = GetAuthor(author.Value);
                        }

                        currentBook.Reviews.Add(review);
                    }
                }

                db.Books.Add(currentBook);
                db.SaveChanges();
            }
        }

        private static Author GetAuthor(string authorName)
        {
            var author = db.Authors.FirstOrDefault(n => n.Name == authorName);
            if (author == null)
            {
                author = new Author
                {
                    Name = authorName
                };
            }
            return author;
        }
    }
}
