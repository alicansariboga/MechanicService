namespace MechanicService.Domain.Entities
{
    public class Faq : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
