using System.ComponentModel.DataAnnotations;

namespace MechanicService.Domain.Entities
{
    public class ReservationService : BaseEntity
    {
        public string City { get; set; }
        public string Distinct { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "Time")]
        public TimeSpan Hour { get; set; }
        public string? Description { get; set; }
    }
}
