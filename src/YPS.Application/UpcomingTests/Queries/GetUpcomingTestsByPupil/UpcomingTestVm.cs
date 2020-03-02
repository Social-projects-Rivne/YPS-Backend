using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.UpcomingTests.Queries.GetUpcomingTestsByPupil
{
    public class UpcomingTestVm : IMapFrom<UpcomingTest>
    {
        public long Id { get; set; }
        public string Date { get; set; }
        public string ScheduledDate { get; set; }
        public string Topic { get; set; }
        public string TestType { get; set; }
        public string Class { get; set; }
        public string Discipline { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<UpcomingTest, UpcomingTestVm>()
                .ForMember(x => x.Date, opt => opt.MapFrom(x => x.Date.ToString("dd.MM.yyyy")))
                .ForMember(x => x.ScheduledDate, opt => opt.MapFrom(x => x.Date.ToString("dd.MM.yyyy")))
                .ForMember(x => x.Class, opt => opt.MapFrom(x => x.Class.Number.ToString() + " - " + x.Class.Character))
                .ForMember(x => x.Discipline, opt => opt.MapFrom(x => x.Discipline.Name));
        }
    }
}
