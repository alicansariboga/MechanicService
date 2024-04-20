namespace MechanicService.Application.Features.Mediator.Results.CarModelResults
{
    public class GetCarModelsByCarBrandIdQueryResult
    {
        public int Id { get; set; }
        public int BrandID { get; set; }
        public string Name { get; set; }
        public string CarType { get; set; }
    }
}
