using System;
using System.Collections.Generic;

namespace SkoleniUtils
{
    public class Student
    {
        public int Id  { get; set; }
        public virtual Name Name  { get; set; }
        public DateTime RegistrationDate  { get; set; }
        public string Note { get; set; }
        public virtual List<Enrollment> Enrollments  { get; set; } = new List<Enrollment>();
    }
}