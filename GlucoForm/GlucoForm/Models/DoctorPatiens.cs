using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlucoForm.Models
{
    public class DoctorPatiens
    {

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }

        public List<Patient> patients { get; set; }

    }
}