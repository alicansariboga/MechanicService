using MechanicService.Application.Enums;
using MechanicService.Application.Features.Mediator.Commands.AppUserCommands;

namespace MechanicService.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;

        public CreateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser
            {
                UserName = request.Username,
                Password = request.Password,
                AppRoleID = (int)RoleTypes.Member, // Member = 3, Admin = 1
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
            });
        }
    }
}
