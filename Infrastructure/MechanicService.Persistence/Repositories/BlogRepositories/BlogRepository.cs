namespace MechanicService.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly MechanicServiceContext _context;

        public BlogRepository(MechanicServiceContext context)
        {
            _context = context;
        }

        public Blog GetBlogWithCategoryName(int id)
        {
            var values = _context.Blogs.Where(x => x.Id == id).Include(x => x.Category).FirstOrDefault();
            return values;
        }

        public List<Blog> GetLast3Blogs()
        {
            var values = _context.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            return values;
        }
    }
}
