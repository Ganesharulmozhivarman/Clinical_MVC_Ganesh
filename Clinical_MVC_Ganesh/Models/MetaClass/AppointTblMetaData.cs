using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinical_MVC_Ganesh.Models
{
    public class AppointTblMetaData
    {
        [Required]
        public int Patient { get; set; }
        [Required]
        public int Doctor { get; set; }
        [Required]
        public int Receptionist { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }

    }
    [MetadataType(typeof(AppointTblMetaData))]
    public partial class AppointTbl
    {

    }
}