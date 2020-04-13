using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Livraria.Models;
using Livraria.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Livraria.ViewModels;
using Livraria.Services;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("/statusbook")]
    public class StatusBookController : ControllerBase
    {
        private readonly IMapper mapper;

        private readonly StatusBookService statusBookService;

        public StatusBookController(IMapper mapper, StatusBookService statusBookService){
            this.mapper = mapper;
            this.statusBookService = statusBookService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<StatusBookViewModel>>> GetStatusBook([FromServices] DataContext context)
        {
            var statusBook = await statusBookService.ListStatusBook();

            var statusBookViewModel = mapper.Map<List<StatusBookViewModel>>(statusBook);

            return Ok(statusBookViewModel);

        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "root")]
        public async Task<ActionResult<StatusBook>> PostCategories(
            [FromServices] DataContext context, [FromBody] StatusBook model)
        {
            if (ModelState.IsValid)
            {
                return await statusBookService.CreateStatusBook(model);
            }

            else
                return BadRequest(ModelState);

        }

        [HttpPut]
        [Route("change/{id:int}")]
        [Authorize]
        public async Task<ActionResult<StatusBook>> UpdateStatusBook(
            [FromServices] DataContext context, [FromBody] StatusBook model, int id)
        {

            return await statusBookService.UpdateStatusBook(model, id);           
        
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<ActionResult<List<StatusBook>>> GetStatusById([FromServices] DataContext context, int id)
        {
            return await statusBookService.GetStatusBoodById(id);
        }
    }
}
