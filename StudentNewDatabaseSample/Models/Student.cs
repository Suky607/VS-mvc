using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentNewDatabaseSample.Models
{
   public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        //相当于数据库的外码
        public int StudentClassId { get; set; }
        //导航属性--目的是能够通过贴纸
        public virtual StudentClass StudentClass { get; set; }
    }
}
