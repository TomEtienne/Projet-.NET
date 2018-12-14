using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class RegisterModel
    {

        [Required]
        [Display(Name = "Nom")]
        public String lastName { get; set; }
        [Required]
        [Display(Name = "Prenom")]
        public String firstName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public String email { get; set; }
        [Required]
        [Display(Name = "Pseudo")]
        public String nickName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Mot de passe de 8 charactères + mélange lettres, majuscules, nombres, caractères spéciaux")]
        public String password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmation de Mot de passe")]
        [Compare(nameof(password))]
        public String verifyPassword { get; set; }


        public RegisterModel() { }

        public RegisterModel(String lastName, String firstName, String email, String nickName, String password, String verifyPassword)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.email = email;
            this.nickName = nickName;
            this.password = password;
            this.verifyPassword = verifyPassword;
        }
    }
}