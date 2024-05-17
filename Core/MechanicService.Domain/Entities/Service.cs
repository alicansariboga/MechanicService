namespace MechanicService.Domain.Entities
{
    public class Service : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public List<ServiceDescription> ServiceDescriptions { get; set; }
    }
}
