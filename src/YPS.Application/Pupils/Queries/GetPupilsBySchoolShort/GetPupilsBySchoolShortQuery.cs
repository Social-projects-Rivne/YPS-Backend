using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YPS.Application.Interfaces;

namespace YPS.Application.Pupils.Queries.GetPupilsBySchoolShort
{
    public sealed class GetPupilsBySchoolShortQuery : IRequest<List<GetPupilsBySchoolShortVm>>
    {
        public long SchoolId { get; set; }
        public long NumbOfClass { get; set; }

        public class GetPupilsBySchoolShortQueryHandler : IRequestHandler<GetPupilsBySchoolShortQuery, List<GetPupilsBySchoolShortVm>>
        {
            private readonly IYPSDbContext _context;
            private readonly IMapper _mapper;

            public GetPupilsBySchoolShortQueryHandler(IYPSDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<GetPupilsBySchoolShortVm>> Handle(GetPupilsBySchoolShortQuery request, CancellationToken cancellationToken)
            {
                var query = from p in _context.Pupils
                            join u in _context.Users on p.Id equals u.Id
                            join ctp in _context.ClassesToPupils on p.Id equals ctp.PupilId into classToPupil
                            from ctpTmp in classToPupil.DefaultIfEmpty()
                            join cl in _context.Classes on ctpTmp.ClassId equals cl.Id into classes
                            from clTmp in classes.DefaultIfEmpty()
                            where clTmp.Number == request.NumbOfClass - 1 || ctpTmp == null
                            select new GetPupilsBySchoolShortVm
                            {
                                Id = p.Id,
                                FullName = u.FirstName + " " + u.MiddleName
                            };

                return await query.ToListAsync().ConfigureAwait(false);
            }
        }
    }
}
