namespace Domain.Tests;

public class Flight
{
    public int SeatCapacity { get; set; }
    public int RemainingNumberOfSeats { get; set; }
    public Flight(int seatCapacity)
    {
        SeatCapacity = seatCapacity;
        RemainingNumberOfSeats = seatCapacity;
    }

    public void Book(string v1, int numberOfSeats)
    {
        RemainingNumberOfSeats -= numberOfSeats;
    }
}
