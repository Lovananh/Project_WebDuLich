using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_WebDuLich.Models
{
	public class TourHotel
	{
        [Key]
        public int ID { get; set; }

        [ForeignKey("Tour")]
        public int TourID { get; set; }

        [ForeignKey("Hotel")]
        public int HotelID { get; set; }

        public virtual Tours Tour { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}