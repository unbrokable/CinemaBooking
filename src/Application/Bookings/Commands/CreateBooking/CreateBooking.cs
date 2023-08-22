using Ardalis.GuardClauses;
using AutoMapper;
using CinemaBooking.Application.BackgroundJobs;
using Hangfire;
using Microsoft.Extensions.Configuration;

namespace CinemaBooking.Application.Bookings.Commands.CreateBooking;

public record CreateBookingCommand : IRequest<BookingDetailsDto>
{
    public int ShowtimeId { get; set; } 

    public IEnumerable<int> SeatIds { get; set; } = Enumerable.Empty<int>();
}

public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingDetailsDto>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;

    private readonly ISender _sender;

    private readonly TimeSpan _timeout;
    public CreateBookingCommandHandler(IApplicationDbContext context, IMapper mapper, ISender sender, IConfiguration configuration)
    {
        _context = context;
        _mapper = mapper;
        _sender = sender;

        _timeout = TimeSpan.Parse(configuration["BookingReservationTimeout"]);
    }

    public async Task<BookingDetailsDto> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        Showtime? showtime = _context.Showtimes
            .Include(s => s.ShowSeats)
            .FirstOrDefault(s => s.Id == request.ShowtimeId);

        Guard.Against.Null(showtime, nameof(request.ShowtimeId));

        IEnumerable<ShowSeat> showSeats = showtime
            .ShowSeats
            .Where(s => request.SeatIds.Contains(s.TheaterSeatId) && !s.IsReserved)
            .ToList();

        if (showSeats.Count() != request.SeatIds.Count())
        {
            throw new ArgumentException("Invalid seat ids. Seats are already reserved.");
        }
       
        var entity = new Booking
        {
            Status = "Pending",
            ShowtimeId = request.ShowtimeId,
        };

        _context.ShowSeats.UpdateRange(showSeats.Select(s =>
        {
            s.Booking = entity;
            s.IsReserved = true;
            return s;
        }));

        _context.Bookings.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        Booking booking = await _context
            .Bookings
            .Include(b => b.Showtime)
            .ThenInclude(b => b!.Movie)
            .Include(b => b.Seats)
            .FirstAsync(b => b.Id == entity.Id);


        BackgroundJob.Schedule<BookingWatcherJob>((j) => j.StartAsync(entity.Id, default), _timeout);

        return _mapper.Map<BookingDetailsDto>(booking);
    }

}