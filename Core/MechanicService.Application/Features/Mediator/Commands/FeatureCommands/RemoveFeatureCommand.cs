using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicService.Application.Features.Mediator.Commands.FeatureCommands
{
    public class RemoveFeatureCommand : IRequest
    {
        public RemoveFeatureCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
