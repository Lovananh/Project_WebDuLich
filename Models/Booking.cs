using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_WebDuLich.Models
{
	public class Booking
	{
        [Key]
        public int BookingID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; } // Khóa ngoại đến User

        [Required]
        [ForeignKey("Tour")]
        public int TourID { get; set; } // Khóa ngoại đến Tour

        [Required]
        public DateTime BookingDate { get; set; } // Ngày đặt tour

        [Required]
        public BookingStatus Status { get; set; } // Trạng thái

        public decimal TotalPrice { get; set; } // Tổng giá

        // Điều hướng
        public virtual User User { get; set; }
        public virtual Tours Tour { get; set; }

        public enum BookingStatus
        {
            Pending,    // Chờ xác nhận
            Confirmed,  // Đã xác nhận
            Canceled    // Đã hủy
        }
    }
}