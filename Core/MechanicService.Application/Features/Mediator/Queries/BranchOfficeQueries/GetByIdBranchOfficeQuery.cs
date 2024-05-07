namespace MechanicService.Application.Features.Mediator.Queries.BranchOfficeQueries
{
    public class GetByIdBranchOfficeQuery : IRequest<GetByIdBranchOfficeQueryResult>
    {
        public GetByIdBranchOfficeQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
