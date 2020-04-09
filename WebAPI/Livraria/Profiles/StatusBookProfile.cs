using AutoMapper;
using Livraria.Models;
using Livraria.ViewModels;

namespace Livraria.Profiles
{
    public class StatusBookProfile : Profile
    {
        public StatusBookProfile(){
            CreateMap<StatusBook, StatusBookViewModel>();
        }
    }
}