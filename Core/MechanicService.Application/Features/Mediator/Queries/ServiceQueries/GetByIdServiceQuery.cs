using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicService.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetByIdServiceQuery : IRequest<GetByIdServiceQueryResult>
    {
        public GetByIdServiceQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
