﻿namespace CinemaBooking.Application.Theaters.Commands.CreateTheater;

public record CreateTheaterCommand : IRequest<int>
{
    public required string Name { get; set; }

    public int SeatRows { get; set; }

    public int SeatColumns { get; set; }

}

public class CreateTheaterCommandHandler : IRequestHandler<CreateTheaterCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTheaterCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTheaterCommand request, CancellationToken cancellationToken)
    {
        var entity = new Theater
        {
            Name = request.Name,
        };

        _context.TheaterSeats.AddRange(Enumerable.Range(0, request.SeatRows)
                .SelectMany(row => Enumerable.Range(0, request.SeatColumns)
                .Select(column => new TheaterSeat
                {
                    Theater = entity,
                    SeatRow = row,
                    SeatColumn = column
                })));

        _context.Theaters.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
