using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SampleApp.API.Application.Commands
{
    public class CreateItemCommand : IRequest<bool>
    {
        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string ProductSize { get; set; }

        public CreateItemCommand()
        {
        }

    }
}
