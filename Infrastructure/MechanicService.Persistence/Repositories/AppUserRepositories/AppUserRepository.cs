using MechanicService.Application.Interfaces.AppUserInterfaces;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MechanicService.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly MechanicServiceContext _context;

        public AppUserRepository(MechanicServiceContext context)
        {
            _context = context;
        }

        public Task CreateAsync(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<AppUser>> GetAllAsync()
        {
            throw new NotImplementedException();
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

        public Task<AppUser?> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public AppUser GetUserInfoFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            var userId = jsonToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var values = _context.AppUsers.Where(x => x.AppUserID == Convert.ToInt32(userId)).Include(x => x.AppRole).FirstOrDefault();

            return (values);
        }

        public Task RemoveAsync(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(AppUser entity)
        {
            _context.Set<AppUser>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
