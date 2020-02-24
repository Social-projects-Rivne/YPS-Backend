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
using YPS.Application.Parents.ViewModels.GetParentsBySchool;

namespace YPS.Application.Parents.Queries.GetParentsBySchool
{
    public class GetParentsBySchoolQuery : IRequest<ICollection<ParentBySchoolVm>>
    {
        public long SchoolId { get; set; }
        public class GetParentsQueryHandler : IRequestHandler<GetParentsBySchoolQuery, ICollection<ParentBySchoolVm>>
        {
            private IYPSDbContext _dbContext;
            private IMapper _mapper;
            public GetParentsQueryHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<ICollection<ParentBySchoolVm>> Handle(GetParentsBySchoolQuery request, CancellationToken cancellationToken)
            {
                return await _dbContext.Users
                    .Include(x => x.Parent)
                    .Where(x => x.Parent != null)
                    .AsNoTracking()
                    .Where(x => x.SchoolId == request.SchoolId)
                    .Select(x => x.Parent)
                    .ProjectTo<ParentBySchoolVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }
    }
}
