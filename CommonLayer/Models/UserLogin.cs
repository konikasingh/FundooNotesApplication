using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "EmailId is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "EmailId:")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password contain six Character")]
        public string Password { get; set; }


        //public string Key
        //{
        //    get;
        //    set;
        //}

        //public readonly string Key = "this is my sample key";
    }
}