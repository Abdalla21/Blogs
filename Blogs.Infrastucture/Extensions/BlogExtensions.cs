using BlogsCore.Domain;
using BlogsCore.DTOs;

namespace Blogs.Infrastucture.Extensions
{
    public static class BlogExtensions
    {
        public static BlogDto ToDto(this Blog blog)
        {
            BlogDto dto = new(blog.Name, blog.Description);

            return dto;
        }

        public static Blog ToBlog(this BlogDto dto)
        {
            Blog blog = new();
            blog.Name = dto.Name;
            blog.Description = dto.Desc;
            blog.ID = Guid.NewGuid();

            return blog;
        }

    }
}
