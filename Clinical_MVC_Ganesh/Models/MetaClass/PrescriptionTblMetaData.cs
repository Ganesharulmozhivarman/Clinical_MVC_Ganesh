using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinical_MVC_Ganesh.Models
{
    public class PrescriptionTblMetaData
    {
        [Required]
        public string Medicines { get; set; }
        
        [Required]
        public int Cost { get; set; }
        
        [DataType(DataType.Date)]
        [Required]
        public System.DateTime Date { get; set; }
    }
    [MetadataType(typeof(PrescriptionTblMetaData))]
    public partial class PrescriptionTbl
    {

    }
}