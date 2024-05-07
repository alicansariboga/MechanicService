namespace MechanicService.Application.Features.Mediator.Results.BranchOfficeResults
{
    public class GetByIdBranchOfficeQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int DistrictId { get; set; }
        public string ImgUrl { get; set; }
        public string LocationUrl { get; set; }
    }
}
