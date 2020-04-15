using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Livraria.Models;
using Livraria.Services;
using Livraria.Repository;
using Livraria.ViewModels;
using Livraria.Data;

namespace Livraria.Controllers
{
    [Route("/admin")]
    public class AdminController : ControllerBase
    {
        
        private readonly RoleManager<IdentityRole> roleManager;
        
        private readonly UserManager<IdentityUser> userManager;


        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager){
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        
        [HttpPost]
        [Route("role")]
        [AllowAnonymous]
        public async Task<ActionResult<CreateRoleViewModel>> CreateRole([FromBody] CreateRoleViewModel model)
        {
            if(ModelState.IsValid){
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if(result.Succeeded){
                    return NoContent();
                }

                foreach(IdentityError error in result.Errors){
                    ModelState.AddModelError("", error.Description);
                }
            }

            return model;
        }

        [HttpPost]
        [Route("userrole")]
        public async Task<ActionResult<UserRoleViewModel>> UserRole([FromBody] UserRoleViewModel model){
            var role = await roleManager.FindByNameAsync(model.RoleName);

            if(role == null)
                throw new ArgumentException("Role inválido.");
            

            var user = await userManager.FindByNameAsync(model.UserName);

            if(!await userManager.IsInRoleAsync(user, role.Name)){
                IdentityResult result = await userManager.AddToRoleAsync(user, role.Name);
            }

            return model;
        }
    }
}