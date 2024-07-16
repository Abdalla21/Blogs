using BlogsCore.Domain;
using BlogsCore.DTOs;
using BlogsCore.IRepository;
using Blogs.Infrastucture.DBContext;
using Blogs.Infrastucture.Extensions;

namespace Blogs.Infrastucture.RepositoryContracts
{
    public class BlogRepository(BlogsDBContext context) : IRepository
    {
        public Guid CreateBlog(Blog blog)
        {
            context.Set<Blog>().Add(blog);
            context.SaveChanges();
            return blog.ID;
        }

        public void DeleteBlog(Guid id)
        {
            Blog? blog = context.Set<Blog>().Find(id);
            if (blog is null)
                return;
            context.Set<Blog>().Remove(blog);
            context.SaveChanges();
        }

        public BlogDto? GetBlog(Guid ID)
        {
            Blog? blog = context.Set<Blog>().Find(ID);
            if (blog is null)
                return null;
            return blog.ToDto();
        }

        public void UpdateBlog(Blog blog)
        {
            context.Set<Blog>().Update(blog);
            context.SaveChanges();
        }

    }
}
