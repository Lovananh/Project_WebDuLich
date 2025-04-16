using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_WebDuLich.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required] public string UserName { get; set; }
        [Required, DataType(DataType.Password)] public string PasswordHash { get; set; }
        [Required, Compare("Password")] public string ConfirmPassword { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }


    }

    // LoginViewModel.cs
    public class LoginViewModel
    {
        //[Required] public string UserName { get; set; }
        //[Required, DataType(DataType.Password)] public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string PasswordHash { get; set; }
    }

}