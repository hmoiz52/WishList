using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using UserBooksList.Models;

namespace UserBooksList
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            using (var db = new UserBooksListContext())
            {
                // Add Test Users
                IList<User> user = new List<User>();
                user.Add(new User() { Email = "Test1@test.com", FirstName = "Test First Name", LastName = "Test Last Name", UserId = 1, Password = "test1" });
                user.Add(new User() { Email = "Test2@test.com", FirstName = "Test Second Name", LastName = "Test Last Name", UserId = 2, Password = "test2" });
                user.Add(new User() { Email = "Test3@test.com", FirstName = "Test Third Name", LastName = "Test Last Name", UserId = 3, Password = "test3" });
                db.Users.AddRange(user);

                // Add Test Books
                IList<Book> book = new List<Book>();
                book.Add(new Book() { Author = "Test Author 1", DateOfPublication = new DateTime(2012,1,1), ISBN = "09876", BookId = 1, Title = "Test title 1" });
                book.Add(new Book() { Author = "Test Author 2", DateOfPublication = new DateTime(2012, 1, 1), ISBN = "09876", BookId = 2, Title = "Test title 2" });
                book.Add(new Book() { Author = "Test Author 3", DateOfPublication = new DateTime(2012, 1, 1), ISBN = "09876", BookId = 3, Title = "Test title 3" });
                db.Books.AddRange(book);

                IList<WishList> wishList = new List<WishList>();
                wishList.Add(new WishList() { BookId = 1, UserId = 1 });
                wishList.Add(new WishList() { BookId = 2, UserId = 1 });
                wishList.Add(new WishList() { BookId = 1, UserId = 2 });
                db.WishLists.AddRange(wishList);

                db.SaveChanges();
            }
        }
    }
}
