using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using CodeFirstNewDatabaseSample.BusinessLayer;
using CodeFirstNewDatabaseSample.DataAccessLayer;
using System.Data.Entity;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //createBlog();
            //QueryBlog();
            //Update();
            //Delete();
            //AddPost();
            //DeletePost();
            //GetBlogId();
            //UpdatePost();
            //Edit();
            SelectPost();

            Console.WriteLine("按任意键退出");
            //Console.ReadKey();
        }
        static void SelectPost()
        {
            Console.WriteLine("请输入将要查找到博客名称：");
            string name = Console.ReadLine();
            PostBusinessLayer pbl = new PostBusinessLayer();
            var query = pbl.QueryForTitle(name);
            foreach (var item in query)
            {
                Console.WriteLine(item.Title + "  " + item.Content);
            }
        }


        //操作
        static void Edit()
        {
            //显示所有博客
            QueryBlog();
            Console.WriteLine("--1-退出 --2-新增博客  --3-更改博客  --4-删除博客  --5-操作帖子");
            Console.WriteLine("请输入操作指令");
            int i = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                return;
            }

            else if (i == 2)
            {
                createBlog();
                QueryBlog();
                Console.Clear();
                Edit();
            }
            else if (i == 3)
            {
                Update();
                QueryBlog();
                Console.Clear();
                Edit();
            }
            else if (i == 4)
            {
                Delete();
                QueryBlog();
                Console.Clear();
                Edit();
            }
            else if (i == 5)
            {

                int blogId = GetBlogId();
                //显示指定博客的帖子列表
                DisplayPosts(blogId);
                PostEdit();

            }
            else
            {
                Console.WriteLine("无效字符");
            }

        }
        static void PostEdit()
        {
            //显示所有博客
            //DisplayPosts(blogId);
            Console.WriteLine("--1-退出 --2-新增帖子  --3-更改帖子  --4-删除帖子  ");
            Console.WriteLine("请输入操作指令");
            int i = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                return;
            }

            else if (i == 2)
            {
                AddPost();               
                Console.Clear();
                PostEdit();
            }
            else if (i == 3)
            {
                UpdatePost();                
                Console.Clear();
                PostEdit();
            }
            else if (i == 4)
            {
                DeletePost();              
                Console.Clear();
                PostEdit();
            }
          
            else
            {
                Console.WriteLine("无效字符");
            }
        }

        //增加贴纸
        static void AddPost()   
        {
            //显示博客列表
            QueryBlog();
            //用户选择某个博客（id）
            int blogId = GetBlogId();
            //Console.WriteLine(blogId);
            //显示指定博客的帖子列表
            DisplayPosts(blogId);
            //根据指定到博客信息创建新帖子   
            //新建贴子
            Post post = new Post();
            //填写贴子属性
            Console.WriteLine("请输入贴子标题");
            post.Title = Console.ReadLine();
            Console.WriteLine("请输入贴子内容");
            post.Content = Console.ReadLine();
            post.BlogId = blogId;
            //贴子通过数据库上下文新增
            using (var db = new BloggingContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }

            //显示指定博客的帖子列表
            DisplayPosts(blogId);
        }
        //删除某个贴纸
        static void DeletePost()
        {
            //显示博客列表
            QueryBlog();
            PostBusinessLayer pbl = new PostBusinessLayer();
            Console.WriteLine("请输入博客ID");
            int blogId = int.Parse(Console.ReadLine());
            DisplayPosts(blogId);
            Console.WriteLine("请输入贴纸ID");
            int postId = int.Parse(Console.ReadLine());
            Post post = pbl.QueryPost(postId);
            pbl.DeletePost(post);
            //显示指定博客的帖子列表
            DisplayPosts(blogId);
        }
        //修改贴纸

        static void UpdatePost()
        {
            QueryBlog();
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            PostBusinessLayer pbl = new PostBusinessLayer();
            Console.WriteLine("请输入一个博客ID");
            int blogId = int.Parse(Console.ReadLine());
            DisplayPosts(blogId);
            Console.WriteLine("请输入想要修改的帖子ID");
            int postId = int.Parse(Console.ReadLine());
            Post post = pbl.QueryPost(postId);
            Console.WriteLine("请入新题目");
            string newtitle = Console.ReadLine();
            post.Title = newtitle;
            Console.WriteLine("请输入新内容");
            string newcontent = Console.ReadLine();
            post.Content = newcontent;
            pbl.UpdatePost(post);
            DisplayPosts(blogId);

        }
        static int GetBlogId()
        {
            //提示用户输入的博客id
            //获取用户输入，并入变量的id
            //返回ID
            Console.WriteLine("提示用户输入的博客id");
            int id = int.Parse(Console.ReadLine());
            return id;

        }
        static void DisplayPosts(int blogId)
        {
            Console.WriteLine(blogId + "的贴子列表");
            List<Post> list = null;
            //根据博客ID获取博客
            using (var db = new BloggingContext())
            {
                //通过上下文
                Blog blog = db.Blogs.Find(blogId);
                //根据博客导航属性，获取所有该博客的贴子
                list = blog.Posts;
            }
            //遍历所有贴子，显示贴子标题（博客号-贴子标题）
            foreach (var item in list)
            {
              
                    Console.WriteLine(item.Blog.BlogId+"  "+item.Title);                   
                }
            }  
  

        //增加博客--交互
        static void createBlog()
        { 
            Console.WriteLine("请输入一个博客的名称");
            string name = Console.ReadLine();//接收一个用户的名字
            Blog blog = new Blog();
            blog.Name = name;
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            bbl.Add(blog);
        }
        //显示全部博客
        static void QueryBlog()
        {
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            var blogs = bbl.Query();
            foreach(var item in blogs)
            {
                Console.WriteLine(item.BlogId + " " + item.Name);
            } 
        }
        //修改博客
        static void Update()
        {
            Console.WriteLine("请输入ID");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Blog blog = bbl.Query(id);
            Console.WriteLine("请输入新名字");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }
        //删除博客
        static void Delete()
        {
            Console.WriteLine("请输入ID");
            int id = int.Parse(Console.ReadLine());
            BlogBusinessLayer bbl = new BlogBusinessLayer();
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }
    }
}
