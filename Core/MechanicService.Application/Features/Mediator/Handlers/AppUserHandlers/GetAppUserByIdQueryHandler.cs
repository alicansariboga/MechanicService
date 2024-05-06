namespace MechanicService.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetAppUserByIdQueryHandler : IRequestHandler<GetAppUserByIdQuery, GetAppUserByIdQueryResult>
    {
        private readonly IRepository<AppUser> _repository;

        public GetAppUserByIdQueryHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<GetAppUserByIdQueryResult> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetAppUserByIdQueryResult
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
