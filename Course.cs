using System;
using System.Collections.Generic;

namespace Holec.SkoleniUtils
{
    public class Course
    {
        public int Id  { get; set; }
        public string Title  { get; set; }
        public DateTime Date  { get; set; }
        public decimal Price  { get; set; }
        
        public virtual List<Enrollment> Enrollments  { get; set; } = new List<Enrollment>();
    }
}