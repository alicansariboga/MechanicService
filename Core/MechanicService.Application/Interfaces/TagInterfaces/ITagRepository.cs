namespace MechanicService.Application.Interfaces.TagInterfaces
{
    public interface ITagRepository
    {
        List<Tag> GetTagByBlogID(int id);
    }
}
