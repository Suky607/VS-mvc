using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentNewDatabaseSample.Models;
using StudentNewDatabaseSample.StudentBusinessLayer;

namespace StudentNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //createStudentClass();
            QueryStudentClass();
            //Update();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }

        static void createStudentClass()
        {
            Console.WriteLine("请输入一个班级的名称");
            string name = Console.ReadLine();//接收一个用户的名字
            StudentClass blog = new StudentClass();
            blog.StudentClassName = name;
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bbl.Add(blog);
        }
        //显示全部博客
        static void QueryStudentClass()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            var blogs = bbl.Query();
            foreach (var item in blogs)
            {
                Console.WriteLine(item.StudentClassId + " " + item.StudentClassName);
            }
        }
        //修改
        static void Update()
        {
            Console.WriteLine("请输入ID");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            StudentClass studentClass = bbl.Query(id);
            Console.WriteLine("请输入新名字");
            string name = Console.ReadLine();
            studentClass.StudentClassName = name;
            bbl.Update(studentClass);
        }
        //删除
        static void Delete()
        {
            Console.WriteLine("请输入ID");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            StudentClass studentClass = bbl.Query(id);
            bbl.Delete(studentClass);
        }
    }
}
