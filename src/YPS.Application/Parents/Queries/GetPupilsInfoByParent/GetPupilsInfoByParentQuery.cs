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

namespace YPS.Application.Parents.Queries.GetPupilsInfoByParent
{
    public class GetPupilsInfoByParentQuery : IRequest<ICollection<GetPupilsInfoByParentVm>>
    {
        public long Id { get; set; }
        public long SchoolId { get; set; }
        public class GetPupilsInfoByParentQueryHandler : IRequestHandler<GetPupilsInfoByParentQuery, ICollection<GetPupilsInfoByParentVm>>
        {
            private readonly IYPSDbContext _dbContext;
            private readonly IMapper _mapper;
            public GetPupilsInfoByParentQueryHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            
            public async Task<ICollection<GetPupilsInfoByParentVm>> Handle(GetPupilsInfoByParentQuery request, CancellationToken cancellationToken)
            {
                return await _dbContext.ParentToPupils
                    .Where(x => x.ParentOf.User.SchoolId == request.SchoolId)
                    .Where(x => x.ParentOf.Id == request.Id)
                    .ProjectTo<GetPupilsInfoByParentVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
