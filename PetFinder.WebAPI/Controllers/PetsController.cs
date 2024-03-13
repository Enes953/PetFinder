using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetFinder.Application.Features.PetImagesFile.Commands.CreatePetImage;
using PetFinder.Application.Features.PetImagesFile.Dtos;
using PetFinder.Application.Features.Pets.Commands.CreatePet;
using PetFinder.Application.Features.Pets.Dtos;
using PetFinder.Application.Features.Pets.Models;
using PetFinder.Application.Features.Pets.Queries.GetByIdPet;
using PetFinder.Application.Features.Pets.Queries.GetListPet;
using PetFinder.Application.Features.Pets.Queries.GetListPetByDynamic;

namespace PetFinder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreatePetCommand createPetCommand)
        {
            CreatedPetDto result = await Mediator.Send(createPetCommand);
            return Created("", result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListPetQuery getListPetQuery = new() { PageRequest = pageRequest };
            PetListModel result = await Mediator.Send(getListPetQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]

        public async Task<IActionResult> GetById([FromRoute] GetByIdPetQuery getByIdPetQuery)
        {
            PetGetByIdDto petGetByIdDto = await Mediator.Send(getByIdPetQuery);

            return Ok(petGetByIdDto);
        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,[FromBody] Dynamic dynamic)
        {
            GetListPetByDynamicQuery getListPetByDynamicQuery = new() { PageRequest = pageRequest ,Dynamic=dynamic };
            PetListModel result = await Mediator.Send(getListPetByDynamicQuery);
            return Ok(result);
        }
        [HttpPost("[action]")]   
        public async Task<IActionResult> Upload([FromQuery] CreatePetImageCommand createPetImageCommand)
        {
            createPetImageCommand.Files = Request.Form.Files;
            CreatedPetImageDto createdPetImageDto = await Mediator.Send(createPetImageCommand);
            return Ok();
        }
    }
}
