using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicService.Application.Features.Mediator.Commands.AddressCommands
{
    public class UpdateAddressCommand : IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Phone { get; set; }
        public string PhoneOpt { get; set; }
        public string LongAddress { get; set; }
        public string Email { get; set; }
    }
}
