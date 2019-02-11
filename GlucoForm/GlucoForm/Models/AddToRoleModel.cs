using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlucoForm.Models
{
    public class AddToRoleModel
    {
        public List<string> Emails { get; set; }
        public List<string> roles { get; set; }

        [Display(Name = "Select role")]
        public string SelectedRole { get; set; }

        [Display(Name = "Select email")]
        public string SelectedEmail { get; set; }

        public AddToRoleModel()
        {
            Emails = new List<string>();
            roles = new List<string>();
        }
    }
}