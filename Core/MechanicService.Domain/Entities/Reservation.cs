using System.ComponentModel.DataAnnotations.Schema;

namespace MechanicService.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        [ForeignKey("RezCarID")]
        public int RezCarID { get; set; }
        public ReservationCar ReservationCar { get; set; }

        [ForeignKey("RezPersonID")]
        public int RezPersonID { get; set; }
        public ReservationPerson ReservationPerson { get; set; }

        [ForeignKey("RezServiceID")]
        public int RezServiceID { get; set; }
        public ReservationService ReservationService { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCanceled { get; set; }
    }
}
