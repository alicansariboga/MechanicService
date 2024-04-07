namespace MechanicService.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetByIdSocialMediaQuery : IRequest<GetByIdSocialMediaQueryResult>
    {
        public GetByIdSocialMediaQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
