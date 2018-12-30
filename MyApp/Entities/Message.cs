using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApp.Entities
{
    public class Message
    {
        [KeyAttribute]
        [Required]
        public Guid id { get; set; }

        [Required]
        [Display(Name = "Auteur du message")]
        public String author { get; set; }

        [Required]
        [Display(Name = "Message posté")]
        public String text { get; set; }

        [Required]
        public DateTime date { get; set; }

        public Message()
        {
            this.id = Guid.NewGuid();
            this.date = DateTime.Now;
        }

    }
}