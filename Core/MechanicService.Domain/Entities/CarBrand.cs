namespace MechanicService.Domain.Entities
{
    public class CarBrand : BaseEntity
    {
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public List<CarModel> CarModels { get; set; }
    }
}
