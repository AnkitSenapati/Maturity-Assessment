using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MaturityDAL.Models
{
    public partial class Register
    {
        public Register()
        {
            ProjectMembers = new HashSet<ProjectMember>();
        }

        public int Userid { get; set; }

        [Required(ErrorMessage = "First Name can not be null")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Last Name can not be null")]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
    }
}
