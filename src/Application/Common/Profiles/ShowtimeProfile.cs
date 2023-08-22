using AutoMapper;
using CinemaBooking.Application.Showtimes.Queries.GetTheaterShowtimes;

namespace CinemaBooking.Application.Common.Profiles
{
    public class ShowtimeProfile : Profile
    {
        public ShowtimeProfile() 
        {
            CreateMap<Showtime, ShowtimeDto>()
              .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.ShowSeats));

            CreateMap<ShowSeat, ShowSeatGetDto>();
        }
    }
}
