using Ancon.API.Models.Resturant.Command.Add;
using Ancon.API.Models.Resturant.Command.Delete;
using Ancon.API.Models.Resturant.Command.Update;
using Ancon.API.Models.Resturant.Queries.Get;
using Ancon.API.Models.Resturant.Queries.GetById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ancon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ResturantsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResturants()
        {
            var applicationQuery = _mapper.Map<Application.Handlers.Resturant.Queries.Get.GetResturantQuery>(new GetResturantQuery());

            var resturants = await _mediator.Send(applicationQuery);
            return Ok(resturants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResturantById([FromRoute] int id)
        {
            var applicationQuery = _mapper.Map<Application.Handlers.Resturant.Queries.GetById.GetByIdResturantQuery>(new GetByIdResturantQuery() { Id = id });

            var resturant = await _mediator.Send(applicationQuery);

            if (resturant == null)
            {
                return NotFound();
            }

            return Ok(resturant);
        }

        [HttpPost]
        public async Task<IActionResult> AddResturant([FromBody] AddResturantCommand command)
        {
            var applicationCommand = _mapper.Map<Application.Handlers.Resturant.Commands.Add.AddResturantCommand>(command);

            var id = await _mediator.Send(applicationCommand);


            return CreatedAtAction(nameof(GetResturantById), new { id = id, controller = "resturants" }, id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateResturant([FromBody] JsonPatchDocument document, [FromRoute] int id)
        {
            var applicationCommand = _mapper.Map<Application.Handlers.Resturant.Commands.Update.UpdateResturantCommand>
                                     (new UpdateResturantCommand() { Id = id, document = document });

            await _mediator.Send(applicationCommand);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResturant(int id)
        {
            var applicationCommand = _mapper.Map<Application.Handlers.Resturant.Commands.Delete.DeleteResturantCommand>
                                     (new DeleteResturantCommand() { Id = id });

            await _mediator.Send(applicationCommand);

            return NoContent();
        }
    }
}
