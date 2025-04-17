using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_WebDuLich.Models
{
	public class Tours
	{
        [Key]
        public int TourID { get; set; }

        [Required]
        public string TourName { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageURL { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public int Duration { get; set; }

        public int AvailableSeats { get; set; }

        // Khóa ngoại
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        [ForeignKey("City")]
        public int CityID { get; set; }

        // Quan hệ
        public virtual Category Category { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<TourHotel> TourHotels { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}