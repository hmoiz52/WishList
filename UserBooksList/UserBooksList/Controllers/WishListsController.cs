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
        private UserBooksListContext db = new UserBooksListContext();

        // GET: api/WishLists
        public IQueryable<WishList> GetWishLists()
        {
            return db.WishLists;
        }

        // GET: api/WishLists/5
        [ResponseType(typeof(WishList))]
        public async Task<IHttpActionResult> GetWishList(int id)
        {
            WishList wishList = await db.WishLists.FindAsync(id);
            if (wishList == null)
            {
                return NotFound();
            }

            return Ok(wishList);
        }

        // PUT: api/WishLists/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWishList(int id, WishList wishList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wishList.UserId)
            {
                return BadRequest();
            }

            db.Entry(wishList).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/WishLists
        [ResponseType(typeof(WishList))]
        public async Task<IHttpActionResult> PostWishList(WishList wishList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WishLists.Add(wishList);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WishListExists(wishList.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = wishList.UserId }, wishList);
        }

        // DELETE: api/WishLists/5
        [ResponseType(typeof(WishList))]
        public async Task<IHttpActionResult> DeleteWishList(int id)
        {
            WishList wishList = await db.WishLists.FindAsync(id);
            if (wishList == null)
            {
                return NotFound();
            }

            db.WishLists.Remove(wishList);
            await db.SaveChangesAsync();

            return Ok(wishList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WishListExists(int id)
        {
            return db.WishLists.Count(e => e.UserId == id) > 0;
        }
    }
}