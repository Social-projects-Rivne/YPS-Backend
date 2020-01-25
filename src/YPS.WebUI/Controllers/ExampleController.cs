using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YPS.Application.Auth.Command.CreateHeadMaster;



namespace YPS.WebUI.Controllers
{
    

    public class ExampleController: BaseController
    {
        /// <summary>
        /// Create new HeadMaster
        /// </summary>
        /// <param name="request">Info of HeadMaster</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateHeadMaster([FromBody] CreateHeadMasterCommand request)
        
        {
            try { 
            var user = await Mediator.Send(request).ConfigureAwait(false);
            return Ok(user);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Invalid something ");
            }



        }






    }
}
