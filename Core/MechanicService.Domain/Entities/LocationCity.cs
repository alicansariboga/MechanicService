namespace MechanicService.Domain.Entities
{
    public class LocationCity : BaseEntity
    {
        public string Name { get; set; }
        public List<LocationDistrict> LocationDistricts { get; set; }
    }
}
