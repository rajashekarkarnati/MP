//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrometheusMini.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Courses_174852
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Courses_174852()
        {
            this.Assignments_174852 = new HashSet<Assignments_174852>();
            this.Enrollment_174852 = new HashSet<Enrollment_174852>();
            this.Homework_174852 = new HashSet<Homework_174852>();
            this.Teaches_174852 = new HashSet<Teaches_174852>();
        }
    
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignments_174852> Assignments_174852 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Enrollment_174852> Enrollment_174852 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Homework_174852> Homework_174852 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teaches_174852> Teaches_174852 { get; set; }
    }
}
