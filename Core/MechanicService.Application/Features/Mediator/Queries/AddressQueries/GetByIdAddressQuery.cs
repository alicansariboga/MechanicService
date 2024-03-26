using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicService.Application.Features.Mediator.Queries.AddressQueries
{
    public class GetByIdAddressQuery : IRequest<GetByIdAddressQueryResult>
    {
        public GetByIdAddressQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
