using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_WebDuLich.Models
{
	public class Category
	{
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string Name { get; set; }

        // Quan hệ với Tour
        public virtual ICollection<Tours> Tours { get; set; }
    }
}