using FluentAssertions;
using Xunit;
using Domain.Tests;

namespace FlightTest
{
    public class FlightTests
    {
        [Fact]
        public void Tests()
        {
            var flight = new Flight(seatCapacity: 3);

            flight.Book("rehan", 1);

            flight.RemainingNumberOfSeats.Should().Be(2);
        }
    }
}