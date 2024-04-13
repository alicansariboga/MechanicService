namespace MechanicService.Domain.Entities
{
    public class LocationDistrict : BaseEntity
    {
        public int CityID { get; set; }
        public LocationCity LocationCity { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
