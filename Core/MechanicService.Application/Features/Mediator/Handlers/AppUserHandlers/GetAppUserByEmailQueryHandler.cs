using MechanicService.Application.Interfaces.AppUserInterfaces;

namespace MechanicService.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetAppUserByEmailQueryHandler : IRequestHandler<GetAppUserByEmailQuery, GetAppUserByEmailQueryResult>
    {
        private readonly IAppUserRepository _repository;

        public GetAppUserByEmailQueryHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAppUserByEmailQueryResult> Handle(GetAppUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAppUserByEmail(request.Mail);
            return new GetAppUserByEmailQueryResult
            {
                AppUserID = values.AppUserID,
                UserName = values.UserName,
                Password = values.Password,
                Name = values.Name,
                Surname = values.Surname,
                Email = values.Email,
                AppRoleID = values.AppRoleID
            };

        }
    }
}
