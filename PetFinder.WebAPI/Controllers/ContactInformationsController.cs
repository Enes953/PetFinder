using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetFinder.Application.Features.ContactInformations.Commands.CreateContactInformation;
using PetFinder.Application.Features.ContactInformations.Dtos;
using PetFinder.Application.Features.ContactInformations.Models;
using PetFinder.Application.Features.ContactInformations.Queries.GetByIdContactInformation;
using PetFinder.Application.Features.ContactInformations.Queries.GetListContactInformation;
using PetFinder.Application.Features.ContactInformations.Queries.GetListContactInformationByDynamic;
using PetFinder.Application.Features.Pets.Dtos;
using PetFinder.Application.Features.Pets.Models;
using PetFinder.Application.Features.Pets.Queries.GetByIdPet;
using PetFinder.Application.Features.Pets.Queries.GetListPet;
using PetFinder.Application.Features.Pets.Queries.GetListPetByDynamic;

namespace PetFinder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateContactInformationCommand createContactInformationCommand)
        {
            CreatedContactInformationDto result = await Mediator.Send(createContactInformationCommand);
            return Created("", result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListContactInformationQuery getListContactInformationQuery = new() { PageRequest = pageRequest };
            ContactInformationListModel result = await Mediator.Send(getListContactInformationQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]

        public async Task<IActionResult> GetById([FromRoute] GetByIdContactInformationQuery getByIdContactInformationQuery)
        {
            ContactInformationGetByIdDto contactInformationGetByIdDto = await Mediator.Send(getByIdContactInformationQuery);

            return Ok(contactInformationGetByIdDto);
        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListContactInformationByDynamicQuery getListContactInformationByDynamicQuery = new() { PageRequest = pageRequest , Dynamic=dynamic};
            ContactInformationListModel result = await Mediator.Send(getListContactInformationByDynamicQuery);
            return Ok(result);
        }
    }
}