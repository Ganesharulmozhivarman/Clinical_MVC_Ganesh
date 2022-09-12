using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinical_MVC_Ganesh.Models
{
    public class DoctorTblMetaData
    {
        [Display(Name ="Doctor Name")]
        [Required(ErrorMessage ="Doctor Name is required")]
        public string DocName { get; set; }

        //[DataType(DataType.Currency)]
        //[Range(1, 9999999999)]
        //[Display(Name = "Phone Number")]
        //[Required(ErrorMessage = "Phone Number Required!")]
        //[RegularExpression(@"^\(?([0-9]{10})\)$",
        //            ErrorMessage = "Entered phone format is not valid.")]

        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string DocPhone { get; set; }

        [Display(Name = "Experience")]
        [Required]
        public int DocExp { get; set; }

        [Display(Name = "Doctor Special")]
        [Required]
        public string DocSpec { get; set; }

        [Display(Name = "Gender")]
        [RegularExpression(@"^(?:male|Male|female|Female)$", ErrorMessage = "Invalid Gender(Enter Only Male or Female)")]
        [Required]
        public string DocGen { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string DocAdd { get; set; }

        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        [Required]
        public System.DateTime DocDOB { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        public string DocPass { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string DocEmail { get; set; }
    }

    [MetadataType(typeof(DoctorTblMetaData))]
    public partial class DoctorTbl
    {

    }


}