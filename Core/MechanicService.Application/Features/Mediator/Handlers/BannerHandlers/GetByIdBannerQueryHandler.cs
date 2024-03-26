using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicService.Application.Features.Mediator.Handlers.BannerHandlers
{
    public class GetByIdBannerQueryHandler : IRequestHandler<GetByIdBannerQuery, GetByIdBannerQueryResult>
    {
        private readonly IRepository<Banner> _repository;

        public GetByIdBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdBannerQueryResult> Handle(GetByIdBannerQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdBannerQueryResult
            {
                Id = values.Id,
                Title = values.Title,
                Description = values.Description,
                MediaUrl = values.MediaUrl,
            };
        }
    }
}
