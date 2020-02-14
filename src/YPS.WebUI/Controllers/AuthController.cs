using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YPS.Application.Auth.Command.Login;
using YPS.Application.Auth.Command.RefreshToken;

namespace YPS.WebUI.Controllers
{
    
    public class AuthController : ApiController
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
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginCommand command)
        {
            command.ApiKey = _apiKey;
            var viewModel = await Mediator.Send(command).ConfigureAwait(false);
            return Ok(viewModel);
        }


        [HttpGet]
        public async Task<ActionResult> Refresh(string token, string refreshToken)
        {
            var command = new RefreshTokenCommand(_apiKey, token, refreshToken);
            return Ok(await Mediator.Send(command).ConfigureAwait(false));
            try
            {   
                command.ApiKey = _apiKey;
                var response = await Mediator.Send(command);
                return Ok(response);
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