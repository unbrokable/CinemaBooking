using AutoMapper;
using CinemaBooking.Application.Movies.Queries.GetMovies;

namespace CinemaBooking.Application.Common.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile() 
        { 
            CreateMap<Movie, MovieDto>();
        }
    }
}
