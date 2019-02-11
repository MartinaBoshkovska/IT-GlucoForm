using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GlucoForm.Models
{
    public class Doctor
    {
        public Doctor()
        {

        }
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; } 


        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Telephone Number")]
        public string TelephoneNumber { get; set; }
        

        [Display(Name = "Workplace")]
        public string WorkPlace { get; set; }

    }
}