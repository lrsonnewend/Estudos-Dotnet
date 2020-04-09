using AutoMapper;
using Livraria.Models;
using Livraria.ViewModels;

namespace Livraria.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile(){
            CreateMap<Category, CategoryViewModel>();
        }
    }
}