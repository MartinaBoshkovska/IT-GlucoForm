using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GlucoForm.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public int PatientId { get; set; }

        //GLUCOSE MEASUREMENT
        [Required]
        [Display(Name = "Date of measurement")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? ReportDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Time of measurement")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime MeasurementTime { get; set; }

        [Required]
        public string Period { get; set; }

        [Required]
        [Display(Name = "Glucose level")]
        public string MeasurementValue { get; set; }

        public string Comment { get; set; }

        public virtual Patient Patient { get; set; }

        //maybe add weight height values for patient for every report

        [Display(Name = "ECG File")]
        public string ECGfile { get; set; }


    }
}