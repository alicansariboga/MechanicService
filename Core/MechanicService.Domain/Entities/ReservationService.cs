namespace MechanicService.Domain.Entities
{
    public class ReservationService : BaseEntity
    {
        public string City { get; set; }
        public string Distinct { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public string? Description { get; set; }
    }
}
