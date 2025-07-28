
namespace Domain;

public class Flight
{
    List<Booking> bookingList = new();
    public IEnumerable<Booking> BookingList => bookingList;
    public int SeatCapacity { get; set; }
    public int RemainingNumberOfSeats { get; set; }
    public Guid Id { get; }
    public Flight(int seatCapacity)
    {
        SeatCapacity = seatCapacity;
        RemainingNumberOfSeats = seatCapacity;
    }

    public object? Book(string passengerEmail, int numberOfSeats)
    {
        if (numberOfSeats > RemainingNumberOfSeats)
        {
            return new OverbookingError();
        }

        RemainingNumberOfSeats -= numberOfSeats;
        bookingList.Add(new Booking(passengerEmail, numberOfSeats));
        return null;
    }

    public object? CancelBooking(string passengerEmail, int numberOfSeats)
    {
        if (!bookingList.Any(booking => booking.Email == passengerEmail))
        {
            return new BookingNotFoundError();
        }

        var booking = bookingList.FirstOrDefault(b => b.Email == passengerEmail)!;
        if (booking.NumberOfSeats < numberOfSeats)
        {
            return new TooManySeatsError();
        }
        RemainingNumberOfSeats += numberOfSeats;
        return null;
    }
}
