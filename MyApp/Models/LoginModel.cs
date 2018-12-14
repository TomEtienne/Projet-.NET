using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Pseudo")]
        public String nickName { get; set; }
        [Required]
        [Display(Name = "Mot de Passe")]
        [DataType(DataType.Password)]
        public String password { get; set; }

        public LoginModel() { }
    }
}