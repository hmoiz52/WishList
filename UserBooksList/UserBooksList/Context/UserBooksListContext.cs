using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UserBooksList.Models
{
    public class UserBooksListContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public UserBooksListContext() : base("name=UserBooksListContext")
        {
        }

        public System.Data.Entity.DbSet<UserBooksList.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<UserBooksList.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<UserBooksList.Models.WishList> WishLists { get; set; }
    }
}
