using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApp.Entities
{
    public class User
    {
        [KeyAttribute]
        [Required]
        public Guid id { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public String lastName { get; set; }
        [Required]
        [Display(Name = "Prenom")]
        public String firstName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public String email { get; set; }
        [Required]
        [Display(Name = "Pseudo")]
        public String nickName { get; set; }
        [Required]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Mot de passe de 8 charactères + mélange lettres, majuscules, nombres, caractères spéciaux")]
        public String password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmation du Mot de Passe")]
        [Compare(nameof(password))]
        public String verifyPassword { get; set; }
        [Display(Name = "Photo de profil")]
        public byte[] UserPhoto { get; set; }

        public User()
        {
            this.id = Guid.NewGuid();
        }
    }
}