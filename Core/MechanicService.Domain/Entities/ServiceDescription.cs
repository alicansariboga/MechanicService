namespace MechanicService.Domain.Entities
{
    public class ServiceDescription : BaseEntity
    {
        public string Description { get; set; }
        public int ServiceID { get; set; }
        public Service Service { get; set; }
    }
}
