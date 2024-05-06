using MechanicService.Application.Interfaces.AppUserInterfaces;

namespace MechanicService.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetAppUserQueryHandler : IRequestHandler<GetAppUserQuery, List<GetAppUserQueryResult>>
    {
        private readonly IAppUserRepository _repository;

        public GetAppUserQueryHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAppUserQueryResult>> Handle(GetAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAppUserAll();
            return values.Select(x => new GetAppUserQueryResult
            {
                AppUserID = x.AppUserID,
                UserName = x.UserName,
                Password = x.Password,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                AppRoleID = x.AppRoleID,
                AppRoleName = x.AppRole.Name,
            }).ToList();
        }
    }
}
