namespace MechanicService.Domain.Entities
{
    public class Banner : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string MediaUrl { get; set; }
    }
}
