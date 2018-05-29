using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaniShop.Models;
using SaniShop.DAL;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;

namespace SaniShop.Models
{
    public class RegiterModal
    {
        
        //public int id { get; set; }
        [Required(ErrorMessage = "Please provide username", AllowEmptyStrings = false)]
        [StringLength(20,ErrorMessage ="user name 6 character",MinimumLength =5)]
        public string username { get; set; }

        [Required(ErrorMessage = "Please provide Password",  AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be 8 char long.")]
        [Display(Name = "Password: ")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Please provide Email", AllowEmptyStrings = false)]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
         ErrorMessage = "Please provide valid email id")]
        [Display(Name = "Email Address: ")]
        public string Email { get; set; }
        
        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string mobile{ get; set; }
        
        public string regiterdate{ get; set; }

        [Required(ErrorMessage = "Please provide city", AllowEmptyStrings = false)]
        [StringLength(20,ErrorMessage ="city minimum 3 character",MinimumLength =3)]
        public string city { get; set; }
    }
}