using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Location { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public TimeSpan Duration { get; set; } // Thời gian của tour (ví dụ: 2 ngày 3 đêm)

        public string ImageURL { get; set; }

        public string Description { get; set; }
    }
}