﻿using AutoMapper;
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

namespace YPS.Application.Teachers.Queries.GetTeacher
{
    public class GetTeachersBySchoolQuery : IRequest<List<TeacherBySchoolVm>>
    {
        public long SchoolId { get; set; }

        public class GetTeachersBySchoolQueryHandler : IRequestHandler<GetTeachersBySchoolQuery, List<TeacherBySchoolVm>>
        {
            private readonly IYPSDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetTeachersBySchoolQueryHandler(IYPSDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<List<TeacherBySchoolVm>> Handle(GetTeachersBySchoolQuery request, CancellationToken cancellationToken)
            {
                List<TeacherBySchoolVm> teachers = await _dbContext.Teachers
                    .Where(x => x.SchoolId == request.SchoolId)
                    .ProjectTo<TeacherBySchoolVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                
                return teachers;
            }
        }
    }
}
