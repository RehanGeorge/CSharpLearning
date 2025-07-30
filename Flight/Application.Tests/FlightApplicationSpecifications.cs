using FluentAssertions;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Application.Tests;

namespace Application.Tests
{
    public class FlightApplicationSpecifications
    {
        readonly Entities _entities = new Entities(new DbContextOptionsBuilder<Entities>()
                .UseInMemoryDatabase("Flights")
                .Options);

        readonly BookingService _bookingService;

        public FlightApplicationSpecifications()
        {
            _bookingService = new BookingService(entities: _entities);
        }

        [Theory]
        [InlineData("M@m.com", 2)]
        [InlineData("a@a.com", 2)]
        public void Remembers_bookings(string passengerEmail, int numberOfSeats)
        {

            var flight = new Flight(3);
            _entities.Flights.Add(flight);

            _bookingService.Book(new BookDto(
                flightId: flight.Id, passengerEmail, numberOfSeats));

            _bookingService.FindBookings(flight.Id).Should().ContainEquivalentOf(
                new BookingRm(passengerEmail, numberOfSeats)
                );
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        public void Frees_up_seats_after_booking(int initialCapacity)
        {
            // Given

            var flight = new Flight(initialCapacity);
            _entities.Flights.Add(flight);

            _bookingService.Book(new BookDto(flightId: flight.Id, passengerEmail: "m@m.com", numberOfSeats: 2));

            // When
            _bookingService.CancelBooking(
                new CancelBookingDto(flightId: flight.Id,
                passengerEmail: "m@m.com",
                numberOfSeats: 2)
                );

            // Then
            _bookingService.GetRemainingNumberOfSeatsFor(flight.Id).Should().Be(initialCapacity);
        }
    }


}