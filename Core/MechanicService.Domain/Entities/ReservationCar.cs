using System.ComponentModel.DataAnnotations.Schema;

namespace MechanicService.Domain.Entities
{
    public class ReservationCar : BaseEntity
    {
        [ForeignKey("BrandID")]
        public int BrandID { get; set; }
        public CarBrand CarBrand { get; set; }

        [ForeignKey("ModelID")]
        public int ModelID { get; set; }
        public CarModel CarModel { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public int Km { get; set; }
    }
}
