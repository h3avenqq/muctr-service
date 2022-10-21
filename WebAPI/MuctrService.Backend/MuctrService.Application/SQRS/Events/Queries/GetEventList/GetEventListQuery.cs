using MediatR;

namespace MuctrService.Application.SQRS.Events.Queries.GetEventList
{
    public class GetEventListQuery : IRequest<EventListVm>
    {
        public int Limit { get; set; }
    }
}
