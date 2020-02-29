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

namespace YPS.Application.Pupils.Queries.GetPupilsById
{
    public sealed class GetPupilByIdQuery : IRequest<PupilByIdVm>
    {
        public long Id;
        public class GetPupilByIdQueryHandler : IRequestHandler<GetPupilByIdQuery, PupilByIdVm>
        {
            private readonly IYPSDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetPupilByIdQueryHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<PupilByIdVm> Handle(GetPupilByIdQuery request, CancellationToken cancellationToken)
            {
                PupilByIdVm pupil = await _dbContext.Pupils
                     .ProjectTo<PupilByIdVm>(_mapper.ConfigurationProvider)
                     .FirstOrDefaultAsync(x => x.UserId == request.Id);
                return pupil;
            }
        }
    }
}
