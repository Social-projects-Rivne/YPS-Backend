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


namespace YPS.Application.Parents.Queries.GetPupilInfoOfParent
{
    public class GetPupilInfoOfParentQuery : IRequest<ICollection<GetPupilInfoOfParentVm>>
    {
        public long Id { get; set; }
        public class GetInfoOfParentPupilQueryHandler : IRequestHandler<GetPupilInfoOfParentQuery, ICollection<GetPupilInfoOfParentVm>>
        {
            private readonly IYPSDbContext _dbContext;
            private readonly IMapper _mapper;
            public GetInfoOfParentPupilQueryHandler (IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<ICollection<GetPupilInfoOfParentVm>> Handle(GetPupilInfoOfParentQuery request, CancellationToken cancellationToken)
            {
                return await _dbContext.ParentToPupils
                    .Where(x => x.ParentOf.UserId == request.Id)
                    .ProjectTo<GetPupilInfoOfParentVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
