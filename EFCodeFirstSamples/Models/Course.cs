using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EFCodeFirstSamples.Models
{
    /// <summary>
    /// 课程实体类
    /// </summary>
    public class Course
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]        
        public int CourseID { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 信用等级
        /// </summary>
        public int Credits { get; set; }
        
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
