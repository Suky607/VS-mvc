using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstNewDatabaseSample.Models;
using System.Data.Entity;


namespace CodeFirstNewDatabaseSample.DataAccessLayer
{
     public class BloggingContext : DbContext
    {
        //通过数据集的方式来获取所有的博客
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
