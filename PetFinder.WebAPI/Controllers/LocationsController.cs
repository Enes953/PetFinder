using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetFinder.Application.Features.Locations.Commands.CreateLocation;
using PetFinder.Application.Features.Locations.Dtos;
using PetFinder.Application.Features.Locations.Models;
using PetFinder.Application.Features.Locations.Queries.GetByIdLocation;
using PetFinder.Application.Features.Locations.Queries.GetListLocaitonByDynamic;
using PetFinder.Application.Features.Locations.Queries.GetListLocation;
using PetFinder.Application.Features.Pets.Dtos;
using PetFinder.Application.Features.Pets.Models;
using PetFinder.Application.Features.Pets.Queries.GetByIdPet;
using PetFinder.Application.Features.Pets.Queries.GetListPet;
using PetFinder.Application.Features.Pets.Queries.GetListPetByDynamic;

namespace PetFinder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateLocationCommand createLocationCommand)
        {
            CreatedLocationDto result = await Mediator.Send(createLocationCommand);
            return Created("", result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLocationQuery getListLocationQuery = new() { PageRequest = pageRequest };
            LocationListModel result = await Mediator.Send(getListLocationQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]

        public async Task<IActionResult> GetById([FromRoute] GetByIdLocationQuery getByIdLocationQuery)
        {
            LocationGetByIdDto locationGetByIdDto = await Mediator.Send(getByIdLocationQuery);

            return Ok(locationGetByIdDto);
        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListLocationByDynamicQuery getListLocationByDynamicQuery = new() { PageRequest = pageRequest , Dynamic=dynamic};
            LocationListModel result = await Mediator.Send(getListLocationByDynamicQuery);
            return Ok(result);
        }
    }
}

