using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StudentNewDatabaseSample.Models;
using StudentNewDatabaseSample.StudentDataAccessLayer;

namespace StudentNewDatabaseSample.StudentBusinessLayer
{
   public class BlogBusinessLayer
    {
        public void Add(StudentClass studentClass)
        {
            using (var db = new BloggingContext())
            {
                db.StudentClass.Add(studentClass);
                db.SaveChanges();
            }
        }
        public List<StudentClass> Query()
        {
            using (var db = new BloggingContext())
            {
                return db.StudentClass.ToList();
            }
        }
        public StudentClass Query(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.StudentClass.Find(id);
            }
        }
        public void Update(StudentClass studentClass)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(studentClass).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(StudentClass studentClass)
        {
            using (var db = new BloggingContext())
            {
                //修改博客的实体状态
                db.Entry(studentClass).State = EntityState.Deleted;
                //保存状态
                db.SaveChanges();
            }
        }
    }
}
