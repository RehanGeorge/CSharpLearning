namespace Domain;

public class Flight
{
    public int SeatCapacity { get; set; }
    public int RemainingNumberOfSeats { get; set; }
    public Flight(int seatCapacity)
    {
        SeatCapacity = seatCapacity;
        RemainingNumberOfSeats = seatCapacity;
    }

    public void Book(string passengerEmail, int numberOfSeats)
    {
        RemainingNumberOfSeats -= numberOfSeats;
    }
}
