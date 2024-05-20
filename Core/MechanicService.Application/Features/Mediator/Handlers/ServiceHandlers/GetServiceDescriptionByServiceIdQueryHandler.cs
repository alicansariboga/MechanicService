using MechanicService.Application.Interfaces.ServiceInterfaces;

namespace MechanicService.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceDescriptionByServiceIdQueryHandler : IRequestHandler<GetServiceDescriptionByServiceIdQuery, List<GetServiceDescriptionByServiceIdQueryResult>>
    {
        private readonly IServiceDescriptionRepository _repository;

        public GetServiceDescriptionByServiceIdQueryHandler(IServiceDescriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceDescriptionByServiceIdQueryResult>> Handle(GetServiceDescriptionByServiceIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetServiceDescriptionByServiceId(request.Id);
            return values.Select(x => new GetServiceDescriptionByServiceIdQueryResult
            {
                Id = x.Id,
                Description = x.Description,
                ImgUrl = x.ImgUrl,
            }).ToList();
        }
    }
}
