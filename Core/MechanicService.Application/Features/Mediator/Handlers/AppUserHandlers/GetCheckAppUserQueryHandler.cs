using MechanicService.Application.Features.Mediator.Queries.AppUserQueries;
using MechanicService.Application.Features.Mediator.Results.AppUserResults;

namespace MechanicService.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IRepository<AppUser> _appUserRepository;
        private readonly IRepository<AppRole> _appRoleRepository;

        public GetCheckAppUserQueryHandler(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserQueryResult();
            var user = await _appUserRepository.GetByFilterAsync(x => x.UserName == request.Username && x.Password == request.Password);
            if (user == null)
            {
                values.IsExist = false;
            }
            else
            {
                values.IsExist = true;
                values.Username = user.UserName;
                values.Role = (await _appRoleRepository.GetByFilterAsync(x => x.AppRoleID == user.AppRoleID)).Name;
                values.AppUserId = user.AppUserID;
            }
            return values;
        }
    }
}