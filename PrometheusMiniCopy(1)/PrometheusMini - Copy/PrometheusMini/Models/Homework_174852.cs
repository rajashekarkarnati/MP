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
    
    public partial class Homework_174852
    {
        public int HomeWorkId { get; set; }
        public string Description { get; set; }
        public string Deadline { get; set; }
        public string ReqTime { get; set; }
        public string LongDescription { get; set; }
        public Nullable<int> CourseId { get; set; }
    
        public virtual Assignments_174852 Assignments_174852 { get; set; }
        public virtual Courses_174852 Courses_174852 { get; set; }
    }
}
