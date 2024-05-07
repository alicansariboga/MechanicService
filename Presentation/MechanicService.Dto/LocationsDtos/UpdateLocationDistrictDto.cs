namespace MechanicService.Dto.LocationsDtos
{
    public class UpdateLocationDistrictDto
    {
        public int Id { get; set; }
        public int CityID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
