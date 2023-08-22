using AutoMapper;
using CinemaBooking.Application.Bookings.Commands.CreateBooking;

namespace CinemaBooking.Application.Common.Profiles
{
    public class BookingDetailsProfile : Profile
    {
        public BookingDetailsProfile() 
        {
            CreateMap<Booking, BookingDetailsDto>()
                .ForMember(b => b.DateTime, m => m.MapFrom(b => b.Showtime.DateTime))
                .ForMember(b => b.TotalPrice, m => m.MapFrom(b => b.Seats.Sum(s => s.Price)))
                .ForMember(b => b.Movie, m => m.MapFrom(b => new MovieDetailsDto
                {
                    Title = b.Showtime.Movie.Title,
                    Id = b.Showtime.Movie.Id,
                }))
                .ForMember(b => b.ReservedSeatsId, m => m.MapFrom(b => b.Seats.Select(s => s.TheaterSeatId).ToList()));
        }
    }
}
