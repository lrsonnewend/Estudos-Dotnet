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
    [Route("/account")]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<IdentityUser> userManager;

        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
         SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<RegisterViewModel>> Register([FromBody] RegisterViewModel model){   
            if(ModelState.IsValid){
                var user  = new IdentityUser{
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if(result.Succeeded){
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return NoContent();
                }

                foreach(IdentityError error in result.Errors){
                    ModelState.AddModelError("", error.Description);
                }
            }

            return model;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<RegisterViewModel>> Login([FromBody] RegisterViewModel model){   
            if(ModelState.IsValid){
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if(result.Succeeded)
                    return Content("Bem vindo");
                
                else{
                    throw new ArgumentException("login inválido.");
                }
            }

            return model;
        }
    }
}