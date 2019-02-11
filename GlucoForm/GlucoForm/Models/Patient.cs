using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GlucoForm.Models
{
    public class Patient
    {
        public Patient()
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
        [Display(Name="Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Email { get; set; }
        

        [Required]
        [Display(Name = "Telephone Number")]
        public string TelephoneNumber { get; set; }

        public virtual ICollection<Report> Reports { get; set; }


        [Display(Name = "Current weight")]
        public float Weight { get; set; }
        [Display(Name = "Current height")]
        public float Height { get; set; }

        [Display(Name="Date of inclusion in the study")]
        public DateTime? DateOfInclusionInTheStudy { get; set; }

        [Display(Name = "Profession")]
        public string profession { get; set; }



        ////additionally to add
        ////prasaj go pano dali so tabeli da gi izvedam site values od opciite ili so dropdowns
        ////Medical history
        [Display(Name = "Known high blood pressure in the past?")]
        public string HighBloodPreasure { get; set; }

        [Display(Name = "Known diabetes mellitus in the past, or abnormal glucose levels")]
        public string knownDiabetesOrAbnormalGlucose { get; set; }

        [Display(Name = "Diabetes mellitus in the family")]
        public string DiabetesMellitusInFamily { get; set; }

        //Habits
        [Display(Name = "Alcohol consumption")]
        public string AlcoholConsumption { get; set; }
        [Display(Name = "Smoking")]
        public string SmokingHabbits { get; set; }
        [Display(Name = "Daily physical activity")]
        public string physicalActivity { get; set; }

        ////Extra section
        public int BMI { get; set; }

        [Display(Name = "Umbilical circumference (cm)")]
        public float UmbilicalCircumference { get; set; }

        [Display(Name = "Medications (daily therapy)")]
        public string Medications { get; set; }

        [Display(Name = "Other relevant information")]
        public string AdditionalInformation { get; set; }

        //Lipid Profile
        [Display(Name = "Total Cholesterole")]
        public float TotalCholesterole { get; set; }
        public float Triglicerides { get; set; }
        [Display(Name = "HDL Cholesterole")]
        public float HDLCholesterole { get; set; }
        [Display(Name = "LDL Cholesterole")]
        public float LDLCholesterole { get; set; }

        ////12-Lead ECG Parameters
        [Display(Name = "PR interval")]
        public float PRinterval { get; set; }
        [Display(Name = "QRS duration")]
        public float QRSduration { get; set; }
        [Display(Name = "QT interval")]
        public float QTinterval { get; set; }
        [Display(Name = "RR interval")]
        public float RRinterval { get; set; }

    }
}