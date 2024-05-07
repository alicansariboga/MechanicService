namespace MechanicService.Domain.Entities
{
    public class BranchOffice : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        [ForeignKey("LocationDistrict")]
        public int DistrictId { get; set; }
        public LocationDistrict LocationDistrict { get; set; }
        public string ImgUrl { get; set; }
        public string LocationUrl { get; set; }
    }
}
