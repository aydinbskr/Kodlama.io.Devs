using Application.Features.Brands.Dtos;
using Application.Features.ProgrammingLanguages.Commands.CreatePL;
using Application.Features.ProgrammingLanguages.Commands.DeletePL;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetByIdPL;
using Application.Features.ProgrammingLanguages.Queries.GetListPL;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PLController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatePLCommand createPLCommand)
        {
            CreatedPLDto result = await Mediator.Send(createPLCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListPLQuery getListPLQuery = new() { PageRequest = pageRequest };
            PLListModel result = await Mediator.Send(getListPLQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdPLQuery getByIdPLQuery)
        {

            PLGetByIdDto plGetByIdDto = await Mediator.Send(getByIdPLQuery);
            return Ok(plGetByIdDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePLCommand updatePLCommand)
        {

            CreatedPLDto result = await Mediator.Send(updatePLCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletePLCommand deletePLCommand)
        {
            CreatedPLDto result = await Mediator.Send(deletePLCommand);
            return Ok(result);
        }
    }
}
