using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace MovieApp.Entity
{
   public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity )]
        public int UserId { get; set; }//property

        [Required(ErrorMessage ="Enter Firstname")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter Lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Mobile Number")]
        public int Mobile { get; set; }
    }
}
