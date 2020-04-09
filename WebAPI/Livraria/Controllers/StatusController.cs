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
    [Route("/status")]
    public class StatusController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly StatusService statusService;

        public StatusController(IMapper mapper, StatusService statusService){
            this.mapper = mapper;
            this.statusService = statusService;
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<List<StatusViewModel>>> GetStatus ([FromServices] DataContext context)
        {
            var status = await statusService.ListStatus();

            var statusViewModel = mapper.Map<List<StatusViewModel>>(status);

            return statusViewModel;
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "root")]
        public async Task<ActionResult<Status>> PostCategories(
            [FromServices] DataContext context, [FromBody] Status status)
        {
            if(ModelState.IsValid){
                context.Status.Add(status);
                await context.SaveChangesAsync();
                return status;
            }

            else
                return BadRequest(ModelState);
            
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [Authorize(Roles = "root")]
        public async Task<ActionResult<Status>> UpdateStatus([FromServices] DataContext context,
        [FromBody] Status status, int id)
        {
            var updateStatus = context.Status.FirstOrDefault(item => item.StatusId == id);

            if(updateStatus != null){
                updateStatus.Name = status.Name;
                
                context.Update(updateStatus);
                
                await context.SaveChangesAsync();
            }

            return updateStatus;
        }

    }
}