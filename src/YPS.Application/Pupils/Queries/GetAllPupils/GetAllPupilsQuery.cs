using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YPS.Application.Interfaces;
using YPS.Application.Pupils.Query.GetAllPupils;

namespace YPS.Application.Pupils.Queries.GetAllPupils
{
    public sealed class GetAllPupilsQuery : IRequest<List<PupilVm>>
    {
        public class GetAllPupilsHandler : IRequestHandler<GetAllPupilsQuery, List<PupilVm>>
        {
            private readonly IYPSDbContext _context;
            //private readonly ICurrentUserInformationService _userInfoService;
            private readonly IMapper _mapper;

            public GetAllPupilsHandler(IYPSDbContext context, /*ICurrentUserInformationService userInformationService, */IMapper mapper)
            {
                _context = context;
                //_userInfoService = userInformationService;
                _mapper = mapper;
            }

            public async Task<List<PupilVm>> Handle(GetAllPupilsQuery request, CancellationToken cancellationToken)
            {
                //var schoolId = _userInfoService.SchoolId;

                var pupils = await _context.Pupils
                        .ProjectTo<PupilVm>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);
                return pupils;
            }
        }
    }
}
