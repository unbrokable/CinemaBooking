using AutoMapper;
using CinemaBooking.Application.Bookings.Commands.CreateBooking;
using CinemaBooking.Application.Common.Interfaces;
using CinemaBooking.Application.Movies.Queries.GetMovies;
using CinemaBooking.Application.Showtimes.Queries.GetTheaterShowtimes;
using CinemaBooking.Domain.Entities;
using NUnit.Framework;
using System.Reflection;
using System.Runtime.Serialization;

namespace CinemaBooking.Application.Tests.Common.Mappings;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config => 
            config.AddMaps(Assembly.GetAssembly(typeof(IApplicationDbContext))));

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Test]
    [TestCase(typeof(Movie), typeof(MovieDto))]
    [TestCase(typeof(Booking), typeof(BookingDetailsDto))]
    [TestCase(typeof(Showtime), typeof(ShowtimeDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        _mapper.Map(instance, source, destination);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

#pragma warning disable SYSLIB0050 // Type or member is obsolete
        return FormatterServices.GetUninitializedObject(type);
#pragma warning restore SYSLIB0050 // Type or member is obsolete
    }
}
