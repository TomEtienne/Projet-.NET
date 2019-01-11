using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class DisplayInfosModel
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
        [Display(Name = "Photo de profil")]
        public byte[] UserPhoto { get; set; }

        public DisplayInfosModel() { }
    }
}