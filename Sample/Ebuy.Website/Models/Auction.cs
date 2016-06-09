using System;
using System.ComponentModel.DataAnnotations;

namespace Ebuy.Website.Models
{
    public class Auction
    {
        [Required]
        [StringLength(50, 
            ErrorMessage = "Title cannot be longer than 50 cahracters")]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, 10000, 
            ErrorMessage = "The auction's starting price must be at least 1")]
        public decimal StartPrice { get; set; }

        public decimal CurrentPrice { get; set; }

        public DateTime EndTime { get; set; }
    }
}