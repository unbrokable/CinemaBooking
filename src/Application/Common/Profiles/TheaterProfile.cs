using AutoMapper;
using CinemaBooking.Application.Theaters.Queries.GetTheaters;

namespace CinemaBooking.Application.Common.Profiles
{
    public class TheaterProfile : Profile
    {
        public TheaterProfile() 
        {
            CreateMap<Theater, TheaterDto>();

            CreateMap<TheaterSeat, SeatDto>();
        }
    }
}
