using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace YPS.Application.Event.Query.GetAllEvents
{
    public sealed class GetAllEventsQuery :IRequest<EventListViewModel>
    {
        [IgnoreDataMember]
        public long SchoolId { get; set; }
        public GetAllEventsQuery(long schoolId)
        {
            SchoolId = schoolId;
        }
    }
}
