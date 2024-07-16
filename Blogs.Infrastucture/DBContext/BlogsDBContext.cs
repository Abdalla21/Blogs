using BlogsCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Infrastucture.DBContext
{
    public class BlogsDBContext : DbContext
    {

        public BlogsDBContext(DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Blog> blogs {  get; set; }
    }
}
