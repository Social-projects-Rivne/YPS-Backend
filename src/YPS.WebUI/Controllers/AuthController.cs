using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YPS.Application.Auth.Command.Login;

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
        public async Task<ActionResult<string>> Login([FromBody] LoginCommand command)
        {
            try
            {   
                command.ApiKey = _apiKey;
                var token = await Mediator.Send(command);
                return Ok(new { token });
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