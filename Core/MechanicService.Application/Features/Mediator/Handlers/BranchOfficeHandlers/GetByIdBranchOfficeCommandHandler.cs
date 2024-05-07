namespace MechanicService.Application.Features.Mediator.Handlers.BranchOfficeHandlers
{
    public class GetByIdBranchOfficeQueryHandler : IRequestHandler<GetByIdBranchOfficeQuery, GetByIdBranchOfficeQueryResult>
    {
        private readonly IRepository<BranchOffice> _repository;

        public GetByIdBranchOfficeQueryHandler(IRepository<BranchOffice> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdBranchOfficeQueryResult> Handle(GetByIdBranchOfficeQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdBranchOfficeQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                Address = values.Address,
                Phone = values.Phone,
                Email = values.Email,
                DistrictId = values.DistrictId,
                ImgUrl = values.ImgUrl,
                LocationUrl = values.LocationUrl,
            };
        }
    }
}
