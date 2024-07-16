using BlogsCore.Domain;
using BlogsCore.DTOs;

namespace BlogsCore.IRepository
{
    public interface IRepository
    {
        Guid CreateBlog(Blog blog);

        void UpdateBlog(Blog blog);

        void DeleteBlog(Guid ID);

        BlogDto GetBlog(Guid ID);
    }
}
