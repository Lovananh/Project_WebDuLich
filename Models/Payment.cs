using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_WebDuLich.Models
{
	public class Payment
	{
        [Key]
        public int PaymentID { get; set; }

        [ForeignKey("Booking")]
        public int BookingID { get; set; }

        public DateTime PaymentDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; } // Ví dụ: "Credit Card", "Bank Transfer", "Momo"

        public virtual Booking Booking { get; set; }
    }
}