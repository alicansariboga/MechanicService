using System.ComponentModel.DataAnnotations.Schema;

namespace MechanicService.Domain.Entities
{
    public class ReservationCar : BaseEntity
    {
        public int ModelID { get; set; }
        public CarModel CarModel { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public int Km { get; set; }
    }
}
