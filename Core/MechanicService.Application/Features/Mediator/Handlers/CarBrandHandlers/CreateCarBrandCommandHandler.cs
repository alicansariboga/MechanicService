using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicService.Application.Features.Mediator.Handlers.CarBrandHandlers
{
    public class CreateCarBrandCommandHandler : IRequestHandler<CreateCarBrandCommand>
    {
        private readonly IRepository<CarBrand> _repository;

        public CreateCarBrandCommandHandler(IRepository<CarBrand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarBrandCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new CarBrand
            {
                Name = request.Name,
                IconUrl = request.IconUrl,
            });
        }
    }
}
