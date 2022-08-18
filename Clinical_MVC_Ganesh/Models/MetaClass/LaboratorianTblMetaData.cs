using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Clinical_MVC_Ganesh.Models
{
    public class LaboratorianTblMetaData
    {

        [Display(Name = "Laboratorian Name")]
        [Required(ErrorMessage = "Laboratorian Name is required")]
        public string LabName { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string LabEmail { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        public string LabPass { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        public string LabPhone { get; set; }
        [Display(Name = "Address")]
        [Required]
        public string LabAddress { get; set; }
        [Display(Name = "Gender")]
        [Required]
        public string LabGen { get; set; }
    }
    [MetadataType(typeof(LaboratorianTblMetaData))]
    public partial class LaboratorianTbl
    {

    }
}