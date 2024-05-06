using MechanicService.Application.Interfaces.AppUserInterfaces;

namespace MechanicService.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly MechanicServiceContext _context;

        public AppUserRepository(MechanicServiceContext context)
        {
            _context = context;
        }

        public List<AppUser> GetAppUserAll()
        {
            var values = _context.AppUsers.Include(x => x.AppRole).ToList();
            return values;
        }

        public AppUser GetAppUserByEmail(string mail)
        {
            // SELECT * FROM AppUsers WHERE AppUsers.Email='mail address'
            var value = _context.AppUsers.Where(x => x.Email == mail).FirstOrDefault();
            return value;
        }
    }
}
