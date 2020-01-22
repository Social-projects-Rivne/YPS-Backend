using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
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

        /// <summary>       
        /// Login
        /// </summary>
        /// <param name="command"></param>                   // XML documentation
        /// <response code="200">Returns user token</response>
        /// <response code="401">Invalid username or password</response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Login([FromBody] LoginCommand command)
        {
            try
            {   
                command.ApiKey = _apiKey;
                var viewModel = await Mediator.Send(command).ConfigureAwait(false);
                return Ok(viewModel);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Invalid password ");
            }
        }
    }
}