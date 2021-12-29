﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entities
{
    public class Notes
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("Id")]

        public virtual User User { get; set; }


        [Required(ErrorMessage = "Title is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Title:")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Message:")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Remainder is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Remainder:")]
        public DateTime Remainder { get; set; }

        [Required(ErrorMessage = "Color is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Color:")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Image:")]
        public string Image { get; set; }

        public bool IsArchive { get; set; }

        public bool IsPin { get; set; }
        public bool IsTrash { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Createat { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Modifiedat { get; set; }

    }
}
