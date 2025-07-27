using FluentAssertions;
using Xunit;
using Domain;

namespace FlightTest
{
    public class FlightSpecifications
    {
        [Theory]
        [InlineData(3, 1, 2)]
        [InlineData(5, 3, 2)]
        [InlineData(50, 24, 26)]
        public void Booking_reduces_the_number_of_seats_by_the_number_of_seats_booked(int seatCapacity, int seatsBooked, int expectedRemainingSeats)
        {
            var flight = new Flight(seatCapacity);
            flight.Book("rehan", seatsBooked);
            flight.RemainingNumberOfSeats.Should().Be(expectedRemainingSeats);
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

        [Fact]
        public void Books_flights_successfully()
        {
            // Given
            var flight = new Flight(seatCapacity: 3);
            // When
            var error = flight.Book("rehan", 2);
            // Then
            error.Should().BeNull();
            flight.RemainingNumberOfSeats.Should().Be(1);
        }

        [Fact]
        public void Remembers_bookings()
        {
            Flight flight = new Flight(seatCapacity: 150);

            flight.Book(passengerEmail: "r@g.com", numberOfSeats: 4);

            flight.BookingList.Should().ContainEquivalentOf(new Booking("r@g.com", 4));
        }

        [Theory]
        [InlineData(15, 2, 1, 14)]
        [InlineData(20, 5, 3, 18)]
        [InlineData(5, 2, 2, 5)]
        public void Canceling_bookings_frees_up_the_seats(int seatCapacity, int initialBooking, int cancelNumber, int expectedRemainingSeats)
        {
            // Given
            var flight = new Flight(seatCapacity);
            flight.Book(passengerEmail: "a@b.com", numberOfSeats: initialBooking);

            // When
            flight.CancelBooking(passengerEmail: "a@b.com", numberOfSeats: cancelNumber);

            // Then
            flight.RemainingNumberOfSeats.Should().Be(expectedRemainingSeats);
        }

        [Fact]
        public void Canceling_non_existent_booking_does_not_change_remaining_seats()
        {
            // Given
            var flight = new Flight(seatCapacity: 10);
            flight.Book(passengerEmail: "a@b.com", numberOfSeats: 2);

            // When
            flight.CancelBooking(passengerEmail: "b@c.com", numberOfSeats: 1);

            // Then
            flight.RemainingNumberOfSeats.Should().Be(8);
        }
    }
}