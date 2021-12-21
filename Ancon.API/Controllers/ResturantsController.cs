﻿using MediatR;
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
        private readonly IMediator mediator;

        public ResturantsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResturants()
        {
            /*var resturants = await resturantRepository.GetAllResturants();*/

            var resturants = await mediator.Send(new Application.Handlers.Resturant.Queries.Get.GetResturantQuery());
            return Ok(resturants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResturantById([FromRoute] int id)
        {
            //var resturant = await resturantRepository.GetResturantById(id);

            var resturant = await mediator.Send(new Application.Handlers.Resturant.Queries.GetById.GetByIdResturantQuery() { Id = id });


            if (resturant == null)
            {
                return NotFound();
            }

            return Ok(resturant);
        }

        [HttpPost]
        public async Task<IActionResult> AddResturant([FromBody] Application.Handlers.Resturant.Commands.Add.AddResturantCommand command)
        {
            //var id = await resturantRepository.AddResturant(resturantmodel);

            var id = await mediator.Send(command);


            return CreatedAtAction(nameof(GetResturantById), new { id = id, controller = "resturants" }, id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateResturant([FromBody] JsonPatchDocument document, [FromRoute] int id)
        {
            //await resturantRepository.UpdateResturant(id, document);

            await mediator.Send(new Application.Handlers.Resturant.Commands.Update.UpdateResturantCommand() { Id = id, document = document });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResturant(int id)
        {
            //await resturantRepository.DeleteResturant(id);

            await mediator.Send(new Application.Handlers.Resturant.Commands.Delete.DeleteResturantCommand() { Id = id });

            return NoContent();
        }
    }
}
