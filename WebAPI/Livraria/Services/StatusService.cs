using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Livraria.Models;
using Livraria.Data;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Livraria.ViewModels;

namespace Livraria.Services
{
    public class StatusService
    {
        private readonly DataContext context;

        public StatusService(DataContext context){
            this.context = context;
        }

        public async Task<List<Status>> ListStatus(){
            return await context.Status.ToListAsync();
        }
    }
}