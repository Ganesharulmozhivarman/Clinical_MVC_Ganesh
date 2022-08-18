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
        [Required]
        public string RecEmail { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string RecAdd { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
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