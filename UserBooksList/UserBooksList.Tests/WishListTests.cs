using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserBooksList.Tests
{
    [TestClass]
    public class WishListTests
    {
        [TestMethod]
        public void AddBookToUsersWishList_IsSuccess()
        {
        }

        [TestMethod]
        public void AddBookToUsersWishList_BookNotExists_ReturnNotFound()
        {
        }

        [TestMethod]
        public void AddBookToUsersWishList_UserNotExists_ReturnNotFound()
        {
        }

        [TestMethod]
        public void AddBookToUsersWishList_RecordExists_ReturnConflict()
        {
        }

        [TestMethod]
        public void DeleteBookFromUsersWishList_IsSuccess()
        {
        }

        [TestMethod]
        public void DeleteBookFromUsersWishList_RecordNotExists_ReturnNotFound()
        {
        }

        [TestMethod]
        public void UpdateBookInUsersWishList_RecordExists_IsSuccess()
        {
        }

        [TestMethod]
        public void UpdateBookInUsersWishList_BookNotExists_ReturnNotFound()
        {
        }

        [TestMethod]
        public void UpdateBookInUsersWishList_RecordNotExists_ReturnNotFound()
        {
        }
    }
}
