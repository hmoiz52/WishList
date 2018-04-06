using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using UserBooksList.Models;

namespace UserBooksList.Controllers
{
    public class WishListsController : ApiController
    {
        private UserBooksListContext db;

        public WishListsController()
        {
            db = new UserBooksListContext();
            db.Configuration.ProxyCreationEnabled = false;
        }

        // POST: api/users/1/wishlist/1
        [ResponseType(typeof(WishList))]
        [Route("api/users/{userId}/wishlist/{bookId}", Name = "UpdateBookInWishList")]
        public async Task<IHttpActionResult> UpdateBookInWishList(int userId, int bookId, WishList wishList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (userId != wishList.UserId)
            {
                return BadRequest();
            }

            if (!BookExists(wishList.BookId))
            {
                return NotFound();
            }

            try
            {
                WishList record = await db.WishLists.FindAsync(userId, bookId);

                if (record == null)
                {
                    return NotFound();
                }

                db.WishLists.Remove(record);
                db.WishLists.Add(wishList);

                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new NotImplementedException();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/users/1/wishlist
        [ResponseType(typeof(WishList))]
        [Route("api/users/{userId}/wishlist", Name = "AddBookInUsersWishList")]
        public async Task<IHttpActionResult> AddBookInUsersWishList(int userId, WishList wishList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (userId != wishList.UserId)
            {
                return BadRequest();
            }

            if (!UserExists(wishList.UserId) || !BookExists(wishList.BookId))
            {
                return NotFound();
            }

            try
            {
                db.WishLists.Add(wishList);
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WishListExists(wishList.UserId, wishList.BookId))
                {
                    return Conflict();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            return CreatedAtRoute("AddBookInUsersWishList", new { id = wishList.UserId }, wishList);
        }

        // DELETE: api/users/5/wishlist/1
        [ResponseType(typeof(WishList))]
        [Route("api/users/{userId}/wishlist/{bookId}", Name = "DeleteBookFromWishList")]
        public async Task<IHttpActionResult> DeleteBookFromWishList(int userId, int bookId)
        {
            var record = await db.WishLists.FindAsync(userId, bookId);

            if (record == null)
            {
                return NotFound();
            }

            db.WishLists.Remove(record);
            await db.SaveChangesAsync();

            return Ok(record);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int userId)
        {
            return db.Users.Count(e => e.UserId == userId) > 0;
        }

        private bool BookExists(int bookId)
        {
            return db.Books.Count(e => e.BookId == bookId) > 0;
        }

        private bool WishListExists(int userId,int bookId)
        {
            return db.WishLists.Count(e => e.BookId == bookId && e.UserId == userId) > 0;
        }
    }
}