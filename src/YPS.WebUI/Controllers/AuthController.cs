using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YPS.Application.Auth.Command.Login;

namespace YPS.WebUI.Controllers
{
    public class AuthController : BaseController
    {
        private readonly string _apiKey;

        public AuthController(IConfiguration config)
        {
            _apiKey = config.GetValue<string>("ApiKey");
        }
        [HttpPost]
        public async Task<ActionResult> SignIn([FromBody] LoginCommand command)
        {
            command.ApiKey = _apiKey;
            var viewModel = await Mediator.Send(command).ConfigureAwait(false);
            return Ok(viewModel);
        }
    }
}