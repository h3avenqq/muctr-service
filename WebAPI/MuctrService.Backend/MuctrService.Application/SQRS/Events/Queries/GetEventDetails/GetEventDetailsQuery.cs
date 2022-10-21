using MediatR;
using System;

namespace MuctrService.Application.SQRS.Events.Queries.GetEventDetails
{
    public class GetEventDetailsQuery : IRequest<EventDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
