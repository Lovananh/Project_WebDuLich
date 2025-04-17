using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_WebDuLich.Models
{
	public class City
	{
        [Key]
        public int CityID { get; set; }

        [Required]
        public string CityName { get; set; }

        // Quan hệ với Tour
        public virtual ICollection<Tours> Tours { get; set; }
    }
}