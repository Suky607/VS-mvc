using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StudentNewDatabaseSample.Models;

namespace StudentNewDatabaseSample.StudentDataAccessLayer
{
   public  class BloggingContext : DbContext
    {
        //通过数据集的方式来获取所有的博客
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClass> StudentClass { get; set; }
    }
}
