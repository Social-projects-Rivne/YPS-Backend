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

namespace YPS.Application.Classes.Queries.GetClassByNumber
{
    public class GetClassByNumberQuery:IRequest<ICollection<GetClassByNumberVm>>
    {
        public long SchoolId { get; set; }
        public int Number { get; set; }

        public class GetClassByNumberQueryHandler : IRequestHandler<GetClassByNumberQuery, ICollection<GetClassByNumberVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetClassByNumberQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ICollection<GetClassByNumberVm>> Handle(GetClassByNumberQuery request, CancellationToken cancellationToken)
            {
                var vm = await _context.Classes
                    .Where(x => x.TeacherOf.User.SchoolId == request.SchoolId && x.Number == request.Number)
                    .ProjectTo<GetClassByNumberVm>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return vm;
            }
        }
    }
}
