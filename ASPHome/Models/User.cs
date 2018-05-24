using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPHome.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid Email (must be - example@ex.ex)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Length less than 6 characters")]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string RePassword { get; set; }

        [Range(18, 99, ErrorMessage = "Value from 18 to 99")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public virtual Country Country { get; set; }

        [Required(ErrorMessage = "City is required")]
        public virtual City City { get; set; }

        [Required(ErrorMessage = "Details is required")]
        [StringLength(50, MinimumLength = 20, ErrorMessage = "Length less than 20 characters")]
        public string Details { get; set; }

        public User()
        {
          
        }
    }
}