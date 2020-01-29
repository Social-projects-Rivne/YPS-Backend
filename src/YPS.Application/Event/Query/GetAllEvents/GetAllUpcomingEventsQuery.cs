﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;

namespace YPS.Application.Event.Query.GetAllEvents
{
    public class GetAllUpcomingEventsQuery : IRequest<List<UpcomingEventVm>>
    {
        public class GetAllUpcomingEventsHandler : IRequestHandler<GetAllUpcomingEventsQuery, List<UpcomingEventVm>>
        {
            private readonly IYPSDbContext _context;
            //private readonly ICurrentUserInformationService _userInfoService;
            private readonly IMapper _mapper;

            public GetAllUpcomingEventsHandler(IYPSDbContext context, /*ICurrentUserInformationService userInformationService, */IMapper mapper)
            {
                _context = context;
                //_userInfoService = userInformationService;
                _mapper = mapper;
            }

            public async Task<List<UpcomingEventVm>> Handle(GetAllUpcomingEventsQuery request, CancellationToken cancellationToken)
            {
                var upcomingEvets = await _context.UpcomingEvents                    
                    .ProjectTo<UpcomingEventVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return upcomingEvets;
            }
        }
    }
}
