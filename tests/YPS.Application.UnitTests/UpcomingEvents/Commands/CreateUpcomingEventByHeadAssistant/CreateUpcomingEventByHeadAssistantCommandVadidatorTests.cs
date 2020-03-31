using AutoMapper;
using FluentValidation.Results;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using YPS.Application.UpcomingEvents.Commands.CreateUpcomingEventByHeadAssistant;
using YPS.Persistence;

namespace YPS.Application.UnitTests.UpcomingEvents.Commands.CreateUpcomingEventByHeadAssistant
{
    public class CreateUpcomingEventByHeadAssistantCommandVadidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenUpcomingEventByHeadAssistantIsExist()
        {
            var command = new CreateUpcomingEventByHeadAssistantCommand
            {
                Title = "Welcome to our school",
                Content = "We want to introduce you all our teachers!",
                ScheduledDate = DateTime.Now.AddDays(7),
                TeacherId = 42,
                SchoolId = 2
            };

            var validator = new CreateUpcomingEventByHeadAssistantCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBeTrue();
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenUpcomingEventByHeadAssistantIsNotExist()
        {
            var command = new CreateUpcomingEventByHeadAssistantCommand
            {
                Title = "",
                Content = "",
                ScheduledDate = DateTime.Now.AddDays(1),
                TeacherId = 42,
                SchoolId = 2
            };

            var validator = new CreateUpcomingEventByHeadAssistantCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBeFalse();
        }
    }
}
