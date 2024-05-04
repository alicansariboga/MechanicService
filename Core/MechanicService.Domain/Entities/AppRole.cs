namespace MechanicService.Domain.Entities
{
    public class AppRole
    {
        public int AppRoleID { get; set; }
        public string Name { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
