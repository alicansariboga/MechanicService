namespace MechanicService.Application.Features.Mediator.Results.BannerResults
{
    public class GetByIdBannerQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MediaUrl { get; set; }
        public string CoverImg { get; set; }
    }
}
