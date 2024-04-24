namespace MechanicService.Application.Features.Mediator.Handlers.ContactHandlers
{
    public class GetByIdContactQueryHandler : IRequestHandler<GetByIdContactQuery, GetByIdContactQueryResult>
    {
        private readonly IRepository<Contact> _repository;
    public GetByIdContactQueryHandler(IRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task<GetByIdContactQueryResult> Handle(GetByIdContactQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetByIdContactQueryResult
        {
            Id = value.Id,
            Name = value.Name,
            Surname = value.Surname,
            Email = value.Email,
            Subject = value.Subject,
            Message = value.Message,
            Isread = value.Isread,
            SendDate = value.SendDate,
        };
    }
}
}
