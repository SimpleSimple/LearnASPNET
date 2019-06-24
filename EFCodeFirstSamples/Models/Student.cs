using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFCodeFirstSamples.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        /// <summary>
        /// 报名日期
        /// </summary>
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}