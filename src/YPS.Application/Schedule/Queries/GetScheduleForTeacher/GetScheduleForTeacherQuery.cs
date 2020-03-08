using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;

namespace YPS.Application.Schedule.Queries.GetScheduleForTeacher
{
    public sealed class GetScheduleForTeacherQuery : IRequest<long>
    {
        public long Id { get; set; }

        public sealed class GetScheduleForTeacherQueryHandler : IRequestHandler<GetScheduleForTeacherQuery, long>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetScheduleForTeacherQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<long> Handle(GetScheduleForTeacherQuery request, CancellationToken cancellationToken)
            {

                return 1;
            }
        }
    }
}
