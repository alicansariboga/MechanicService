namespace MechanicService.Application.Features.Mediator.Handlers.BranchOfficeHandlers
{
    public class GetBranchOfficeQueryHandler : IRequestHandler<GetBranchOfficeQuery, List<GetBranchOfficeQueryResult>>
    {
        private readonly IRepository<BranchOffice> _repository;

        public GetBranchOfficeQueryHandler(IRepository<BranchOffice> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBranchOfficeQueryResult>> Handle(GetBranchOfficeQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBranchOfficeQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Phone = x.Phone,
                Email = x.Email,
                DistrictId = x.DistrictId,
                ImgUrl = x.ImgUrl,
                LocationUrl = x.LocationUrl
            }).ToList();
        }
    }
}
