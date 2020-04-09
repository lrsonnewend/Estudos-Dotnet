using AutoMapper;
using Livraria.Models;
using Livraria.ViewModels;

namespace Livraria.Profiles
{
    public class StatusProfile : Profile
    {
        public StatusProfile(){
            CreateMap<Status, StatusViewModel>();
        }
    }
}