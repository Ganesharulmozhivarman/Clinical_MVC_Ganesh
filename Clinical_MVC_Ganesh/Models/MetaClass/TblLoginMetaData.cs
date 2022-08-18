using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Clinical_MVC_Ganesh.Models
{
    public class TblLoginMetaData
    {
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string MailID { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
       
        [Display(Name = "Role")]
        [Required(ErrorMessage ="Role is Mandatory")]
        public string Role { get; set; }
    }
    [MetadataType(typeof(TblLoginMetaData))]
    public partial class TblLogin
    {

    }

}