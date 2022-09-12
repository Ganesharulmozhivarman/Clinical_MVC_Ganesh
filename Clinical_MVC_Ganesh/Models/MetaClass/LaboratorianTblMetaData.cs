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
        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]

        public string LabPhone { get; set; }
        [Display(Name = "Address")]
        [Required]
        public string LabAddress { get; set; }
        [Display(Name = "Gender")]
        [RegularExpression(@"^(?:male|Male|female|Female)$", ErrorMessage = "Invalid Gender(Enter Only Male or Female)")]
        [Required]
        public string LabGen { get; set; }
    }
    [MetadataType(typeof(LaboratorianTblMetaData))]
    public partial class LaboratorianTbl
    {

    }
}