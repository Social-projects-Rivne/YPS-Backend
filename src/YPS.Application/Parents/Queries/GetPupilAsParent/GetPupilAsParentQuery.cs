using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YPS.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace YPS.Application.Parents.Queries.GetPupilAsParent
{
    public sealed class GetPupilAsParentQuery : IRequest<GetPupilAsParentVm>
    {
        public long Id { get; set; }
        public class GetPupilByIdQueryHandler : IRequestHandler<GetPupilAsParentQuery, GetPupilAsParentVm>
        {
            private readonly IYPSDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetPupilByIdQueryHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<GetPupilAsParentVm> Handle(GetPupilAsParentQuery request, CancellationToken cancellationToken)
            {
                GetPupilAsParentVm pupil = await _dbContext.Pupils
                     .ProjectTo<GetPupilAsParentVm>(_mapper.ConfigurationProvider)
                     .FirstOrDefaultAsync(x => x.UserId == request.Id);
                return pupil;
            }
        }
    }
}
