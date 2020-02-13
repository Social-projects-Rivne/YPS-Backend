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
using YPS.Application.Parents.ViewModels;

namespace YPS.Application.Parents.Queries
{
    public class GetParentsQuery : IRequest<ICollection<ParentViewModel>>
    {
        public long Id { get; set; }
        public class GetParentsQueryHandler : IRequestHandler<GetParentsQuery, ICollection<ParentViewModel>>
        {
            private IYPSDbContext _dbContext;
            private IMapper _mapper;
            public GetParentsQueryHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<ICollection<ParentViewModel>> Handle(GetParentsQuery request, CancellationToken cancellationToken)
            {

                return await _dbContext.Users
                    .Include(x => x.Parent)
                    .Where(x => x.Parent != null)
                    .AsNoTracking()
                    .Where(x => x.Parent.SchoolId == request.Id)
                    .Select(x => x.Parent)
                    .ProjectTo<ParentViewModel>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }
    }
}
