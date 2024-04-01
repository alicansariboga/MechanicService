using System.ComponentModel.DataAnnotations.Schema;

namespace MechanicService.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public int RezCarID { get; set; }
        public ReservationCar ReservationCar { get; set; }

        public int RezPersonID { get; set; }
        public ReservationPerson ReservationPerson { get; set; }

        public int RezServiceID { get; set; }
        public ReservationService ReservationService { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCanceled { get; set; }
    }
}
