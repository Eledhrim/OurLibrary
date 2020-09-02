using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OurLibrary.Models
{
    public class Publisher
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Publisher Name")]
        public string Name { get; set; }

        
    }
}
