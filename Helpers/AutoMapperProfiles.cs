using Aria.DTOs;
using AutoMapper;
using Aria.Entities;

namespace Aria.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<MovieCreationDTO, Movie>();

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<CategoryCreationDTO, Category>();
        }
    }
}