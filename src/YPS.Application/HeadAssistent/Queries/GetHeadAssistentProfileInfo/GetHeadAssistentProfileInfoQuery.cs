using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;

namespace YPS.Application.HeadAssistent.Queries.GetHeadAssistentProfileInfo
{
    public class GetHeadAssistentProfileInfoQuery : IRequest<HeadAssistentProfileInfoVm>
    {
        public long Id;
        public class GetTeacherProfileInfoQueryHandler : IRequestHandler<GetHeadAssistentProfileInfoQuery, HeadAssistentProfileInfoVm>
        {
            private readonly IYPSDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetTeacherProfileInfoQueryHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<HeadAssistentProfileInfoVm> Handle(GetHeadAssistentProfileInfoQuery request, CancellationToken cancellationToken)
            {
                HeadAssistentProfileInfoVm headAssistent = await _dbContext.Teachers
                    .ProjectTo<HeadAssistentProfileInfoVm>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.UserId == request.Id);

                return headAssistent;
            }
        }
    }
}
