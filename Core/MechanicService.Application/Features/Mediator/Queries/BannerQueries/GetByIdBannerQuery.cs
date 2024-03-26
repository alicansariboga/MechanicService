namespace MechanicService.Application.Features.Mediator.Queries.BannerQueries
{
    public class GetByIdBannerQuery : IRequest<GetByIdBannerQueryResult>
    {
        public GetByIdBannerQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
