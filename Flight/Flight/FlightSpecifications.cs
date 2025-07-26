using FluentAssertions;
using Xunit;
using Domain;

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

        [Fact]
        public void Avoid_Overbooking()
        {
            // Given
            var flight = new Flight(seatCapacity: 3);

            // When
            var error = flight.Book("rehan", 4);

            // Then
            error.Should().BeOfType<OverbookingError>();
        }
    }
}