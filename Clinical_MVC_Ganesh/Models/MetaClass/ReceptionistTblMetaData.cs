using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Clinical_MVC_Ganesh.Models
{
    public class ReceptionistTblMetaData
    {
        [Display(Name = "Receptionist Name")]
        [Required(ErrorMessage = "Doctor Name is required")]
        public string RecName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^(?:male|Male|female|Female)$", ErrorMessage = "Invalid Gender(Enter Only Male or Female)")]
        [Required]
        public string RecEmail { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string RecAdd { get; set; }

        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]

        public string RecPhone { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        public string RecPassword { get; set; }
    }
    [MetadataType(typeof(ReceptionistTblMetaData))]
    public partial class ReceptionistTbl
    {

    }
}