using Application.Features.Socials.Commands.CreateSocial;
using Application.Features.Socials.Dtos;
using ApSocialication.Features.Socials.Commands.DeleteSocial;
using ApSocialication.Features.Socials.Commands.UpdateSocial;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialCommand createSocialCommand)
        {
            CreatedSocialDto result = await Mediator.Send(createSocialCommand);
            return Created("", result);
        }



        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSocialCommand updateSocialCommand)
        {

            UpdatedSocialDto result = await Mediator.Send(updateSocialCommand);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSocialCommand deleteSocialCommand)
        {
            DeletedSocialDto result = await Mediator.Send(deleteSocialCommand);
            return Ok(result);
        }

    }
}
