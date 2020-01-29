using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using YPS.Application.SchoolRequests.ViewModel;

namespace YPS.Application.SchoolRequests.Queries
{
    public class GetRequestsQuery : IRequest<ICollection<SchoolRequestViewModel>>
    {
        public class GetRequestQueryHandler : IRequestHandler<GetRequestsQuery, ICollection<SchoolRequestViewModel>>
        {
            private IYPSDbContext _dbContext;
            private IMapper _mapper;
            public GetRequestQueryHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<ICollection<SchoolRequestViewModel>> Handle(GetRequestsQuery request, CancellationToken cancellationToken)
            {
                var requests = _dbContext.SchoolRequests.Where(x => x.IsApproved == null);
                var requiredRequests = requests.Select(x => new SchoolRequestViewModel
                {
                    Name = x.Name,
                    ShortName=x.ShortName,
                    Address=x.Address,
                    Email=x.Email,
                    Id=x.Id,
                    Locality=x.Locality
                }).ToList();
                return requiredRequests;
            }
        }
    }
}
