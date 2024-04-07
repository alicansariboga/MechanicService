namespace MechanicService.Application.Features.Mediator.Results.TeamResults
{
    public class GetTeamQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public bool Gender { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime WorkStartDate { get; set; }
    }
}
