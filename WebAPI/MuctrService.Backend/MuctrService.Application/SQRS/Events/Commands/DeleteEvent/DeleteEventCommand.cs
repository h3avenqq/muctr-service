using System;
using MediatR;

namespace MuctrService.Application.SQRS.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
