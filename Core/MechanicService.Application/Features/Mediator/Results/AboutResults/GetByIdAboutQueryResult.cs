namespace MechanicService.Application.Features.Mediator.Results.AboutResults
{
    public class GetByIdAboutQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
    }
}
