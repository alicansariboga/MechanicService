namespace MechanicService.Application.Interfaces.AppUserInterfaces
{
    public interface IAppUserRepository
    {
        AppUser GetAppUserByEmail(string mail);
        List<AppUser> GetAppUserAll();
    }
}
