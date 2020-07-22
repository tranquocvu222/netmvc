using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Areas.Admin.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Mời bạn nhập Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}