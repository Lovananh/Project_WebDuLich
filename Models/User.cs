using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_WebDuLich.Models
{
	public class User
	{
        [Key]
        public int UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Lưu mật khẩu đã mã hóa

        [Required]
        public string Role { get; set; } // Admin, User

        [Required, Phone]
        public string Phone { get; set; } // Chuyển thành string để không mất số 0 đầu tiên

    }
}