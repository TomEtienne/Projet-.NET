using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class DisplayInfosMessage
    {
        [Required]
        [Display(Name = "Auteur du message")]
        public String author { get; set; }

        [Required]
        [Display(Name = "Message posté")]
        public String text { get; set; }

        [Required]
        public DateTime date { get; set; }

        public DisplayInfosMessage()
        {
            this.date = DateTime.Now;
        }
    }
}