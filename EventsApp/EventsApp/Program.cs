namespace EventsApp
{

    public delegate void Notify(string message);

    public delegate void TemperatureChangeHandler(string message);

    public class TemperatureMonitor
    {
        public event TemperatureChangeHandler OnTemperatureChanged;

        private int _temperature;
        public int Temperature { get => _temperature;
            set
            {
                _temperature = value;
                if(_temperature > 30)
                {
                    // RAISE EVENT
                    RaiseTemperatureChangedEvent("Temperature exceeded 30 degrees Celsius!");
                }
            }
        }

        protected virtual void RaiseTemperatureChangedEvent(string message)
        {
            OnTemperatureChanged?.Invoke(message);
        }
    }

    public class TemperatureAlert
    {
        public void OnTemperatureChanged(string message)
        {
            Console.WriteLine($"Alert: {message}");
        }
    }

    public class EventPublisher
    {
        public event Notify OnNotify;

        public void RaiseEvent(string message)
        {
            OnNotify?.Invoke(message);
        }
    }

    public class EventSubscriber
    {
        public void OnEventRaised(string message)
        {
            Console.WriteLine($"Event received with message: {message}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            EventPublisher publisher = new EventPublisher();
            EventSubscriber subscriber = new EventSubscriber();
            publisher.OnNotify += subscriber.OnEventRaised;

            publisher.RaiseEvent("This is a test event message.");

            TemperatureMonitor monitor = new TemperatureMonitor();
            TemperatureAlert alert = new TemperatureAlert();
            monitor.OnTemperatureChanged += alert.OnTemperatureChanged;

            monitor.Temperature = 32; // This will trigger the alert
            monitor.Temperature = 28; // This will not trigger the alert
        }
    }
}
