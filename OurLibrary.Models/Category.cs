using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OurLibrary.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Display(Name = "Parent Category")]
        public int? ParentCategoryId { get; set; }
        
        [ForeignKey("ParentCategoryId")]
        public Category ParentCategory { get; set; }

        public List<Category> ChildCategories { get; set; }
    }
}
