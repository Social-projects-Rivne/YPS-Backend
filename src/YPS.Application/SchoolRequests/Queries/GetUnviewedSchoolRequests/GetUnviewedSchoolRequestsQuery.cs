using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;

namespace YPS.Application.SchoolRequests.Queries.GetUnviewedSchoolRequests
{
    public class GetUnviewedSchoolRequestsQuery : IRequest<ICollection<SchoolRequestVm>>
    {
        public class GetUnviewedSchoolRequestQueryHandler : IRequestHandler<GetUnviewedSchoolRequestsQuery, ICollection<SchoolRequestVm>>
        {
            private IYPSDbContext _dbContext;
            private IMapper _mapper;
            public GetUnviewedSchoolRequestQueryHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<ICollection<SchoolRequestVm>> Handle(GetUnviewedSchoolRequestsQuery request, CancellationToken cancellationToken)
            {
                var requests = _dbContext.SchoolRequests
                    .Where(x => x.IsApproved == null)
                    .ProjectTo<SchoolRequestVm>(_mapper.ConfigurationProvider).ToList();
                return requests;
            }
        }
    }
}
