using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserBooksList.Models
{
    [Table("WishList")]
    public class WishList
    {
        [Required]
        [Key]
        [ForeignKey("User")]
        [Column(Order = 0)]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [Key]
        [ForeignKey("Book")]
        [Column(Order = 1)]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}