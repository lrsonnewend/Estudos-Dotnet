using AutoMapper;
using Livraria.Models;
using Livraria.ViewModels;

namespace Livraria.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile(){
            CreateMap<Book, BookViewModel>();
        }
    }
}