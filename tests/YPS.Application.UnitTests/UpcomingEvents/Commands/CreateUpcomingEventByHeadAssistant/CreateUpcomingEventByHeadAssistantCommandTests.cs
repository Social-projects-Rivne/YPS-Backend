using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using YPS.Application.UpcomingEvents.Commands.CreateUpcomingEventByHeadAssistant;
using YPS.Persistence;

namespace YPS.Application.UnitTests.UpcomingEvents.Commands.CreateUpcomingEventByHeadAssistant
{
    public class CreateUpcomingEventByHeadAssistantCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistUpcomingEventByHeadAssistant()
        {
            var command = new CreateUpcomingEventByHeadAssistantCommand
            {
                Title = "Welcome to our school",
                Content = "We want to introduce you all our teachers!",
                ScheduledDate = DateTime.Now.AddDays(6),
                TeacherId = 42,
                SchoolId = 2
            };

            var handler = new CreateUpcomingEventByHeadAssistantCommand.CreateUpcomingEventCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.UpcomingEvents.Find(result);

            entity.ShouldNotBeNull();
            entity.Title.ShouldBe(command.Title);
            entity.Content.ShouldBe(command.Content);
            entity.ScheduledDate.ShouldBe(command.ScheduledDate);
            entity.TeacherId.ShouldBe(command.TeacherId);
            entity.SchoolId.ShouldBe(command.SchoolId);
        }
    }
}
