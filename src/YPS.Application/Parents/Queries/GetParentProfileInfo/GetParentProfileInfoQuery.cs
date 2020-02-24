using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;

namespace YPS.Application.Parents.Queries.GetParentProfileInfo
{
    public class GetParentsBySchoolQuety : IRequest<GetParentProfileInfoVm>
    {
        public long Id;
        public class GetParentProfileInfoQueryHandler : IRequestHandler<GetParentsBySchoolQuety, GetParentProfileInfoVm>
        {
            private readonly IYPSDbContext _dbContext;
            private readonly IMapper _mapper;
            public GetParentProfileInfoQueryHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<GetParentProfileInfoVm> Handle(GetParentsBySchoolQuety request, CancellationToken cancellationToken)
            {
                var parentinfo = await _dbContext.Parents
                    .ProjectTo<GetParentProfileInfoVm>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(x => x.UserId == request.Id);
                return parentinfo;
            }
        }
    }
}
