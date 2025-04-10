using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_WebDuLich.Models
{
	public class News
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tự động tăng
        public int NewsID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey("Tour")]
        public int? TourID { get; set; } // Khóa ngoại (có thể null nếu tin tức không liên quan đến Tour)

        public string Location { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now; // Ngày tạo

        // Điều hướng
        public virtual Tours Tour { get; set; }
    }
}