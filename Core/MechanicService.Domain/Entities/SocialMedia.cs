namespace MechanicService.Domain.Entities
{
    public class SocialMedia : BaseEntity
    {
        public string Name { get; set; }
        public string LinkUrl { get; set; }
        public string IconUrl { get; set; }
    }
}
