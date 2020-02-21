using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YPS.Application.Auth.Command.RefreshToken;

namespace YPS.WebUI.Controllers
{

    public class RefreshTokenController : ApiController
    {
        private readonly string _apiKey;

        public RefreshTokenController(IConfiguration config)
        {
            _apiKey = config.GetValue<string>("ApiKey");
        }
        [HttpPost]
        public async Task<ActionResult> Refresh([FromBody] RefreshTokenCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}