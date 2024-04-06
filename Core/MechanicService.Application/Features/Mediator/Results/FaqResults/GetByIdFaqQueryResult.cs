namespace MechanicService.Application.Features.Mediator.Results.FaqResults
{
    public class GetByIdFaqQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
