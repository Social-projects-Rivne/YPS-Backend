using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace YPS.Application.Days.Queries.GetAllDays
{
    public sealed class GetAllDaysQuery : IRequest<List<DayViewModel>>
    { 
        public class GetAllDaysQueryHandler : IRequestHandler<GetAllDaysQuery, List<DayViewModel>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetAllDaysQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<DayViewModel>> Handle(GetAllDaysQuery request, CancellationToken cancellationToken) =>
                await _context.Days.ProjectTo<DayViewModel>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }
    }
}
