using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Interfaces.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Event.Models
{
    public sealed class EventDto : IHaveCustomMapping
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateOfCreating { get; set; }
        public long TeacherId { get; set; }
        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<UpcomingEvent, EventDto>();
        }
    }
}
