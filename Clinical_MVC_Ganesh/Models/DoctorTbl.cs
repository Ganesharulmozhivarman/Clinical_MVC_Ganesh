//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clinical_MVC_Ganesh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class DoctorTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DoctorTbl()
        {
            this.PrescriptionTbls = new HashSet<PrescriptionTbl>();
            this.AppointTbls = new HashSet<AppointTbl>();
        }
    
        public int DocId { get; set; }
        
        public string DocName { get; set; }

        //[DataType(DataType.Currency)]
        //[Range (1,9999999999)]
        //[Display(Name = "Phone Number")]

        //[Required(ErrorMessage = "Phone Number Required!")]
        //[RegularExpression(@"^\(?([0-9]{10})\)$",
        //           ErrorMessage = "Entered phone format is not valid.")]
        public string DocPhone { get; set; }
        public int DocExp { get; set; }
        public string DocSpec { get; set; }
        public string DocGen { get; set; }
        public string DocAdd { get; set; }
        public System.DateTime DocDOB { get; set; }
        public string DocPass { get; set; }
        public string DocEmail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrescriptionTbl> PrescriptionTbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AppointTbl> AppointTbls { get; set; }
    }
}
