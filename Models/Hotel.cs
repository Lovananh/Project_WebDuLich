using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_WebDuLich.Models
{
	public class Hotel
	{
        [Key]
        public int HotelID { get; set; }

        [Required]
        public string HotelName { get; set; }

        public string Address { get; set; }

        [Phone]
        public string Phone { get; set; }

        // Quan hệ nhiều nhiều với Tour
        public virtual ICollection<TourHotel> TourHotels { get; set; }
    }
}