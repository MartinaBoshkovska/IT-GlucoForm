using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlucoForm.Models
{
    public class ReportsFileViewModel
    {
        public Report report { get; set; }
        public HttpPostedFileBase file { get; set; }

        public ReportsFileViewModel()
        {
            report = null;
            file = null;
        }
    }
}