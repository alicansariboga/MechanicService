using MechanicService.Application.Features.Mediator.Commands.AppUserCommands;

namespace MechanicService.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;

        public UpdateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.AppUserID);
            values.UserName = request.Username;
            values.Password = request.Password;
            values.Name = request.Name;
            values.Surname = request.Surname;
            values.Email = request.Email;
            values.AppRoleID = request.AppRoleID;
            await _repository.UpdateAsync(values);
        }
    }
}
