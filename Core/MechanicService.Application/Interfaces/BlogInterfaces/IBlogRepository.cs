namespace MechanicService.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        List<Blog> GetLast3Blogs();
        Blog GetBlogWithCategoryName(int id);
    }
}
