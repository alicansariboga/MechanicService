using MechanicService.Application.Interfaces.TagInterfaces;

namespace MechanicService.Persistence.Repositories.TagRepositories
{
    public class TagRepository : ITagRepository
    {
        private readonly MechanicServiceContext _context;

        public TagRepository(MechanicServiceContext context)
        {
            _context = context;
        }

        public List<Tag> GetTagByBlogID(int id)
        {
            var values = _context.Tags.Where(x => x.BlogID == id).ToList();
            return values;
        }
    }
}
