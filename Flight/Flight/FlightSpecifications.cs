using FluentAssertions;
using Xunit;
using Domain.Tests;

namespace FlightTest
{
    public class FlightSpecifications
    {
        [Fact]
        public void Booking_reduces_the_number_of_seats_by_the_number_of_seats_booked()
        {
            var flight = new Flight(seatCapacity: 3);
            flight.Book("rehan", 2);
            flight.RemainingNumberOfSeats.Should().Be(1);
        }
    }
}