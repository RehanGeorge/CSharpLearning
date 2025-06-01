namespace EventsApp
{

    //public delegate void Notify(string message);

    //public delegate void TemperatureChangeHandler(string message);

    public class TemperatureChangedEventArgs : EventArgs
    {
        public int Temperature { get;  }
        public TemperatureChangedEventArgs(int temperature)
        {
            Temperature = temperature;
        }
    }

    public class TemperatureMonitor
    {
        //public event TemperatureChangeHandler OnTemperatureChanged;

        public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

        private int _temperature;
        public int Temperature { get => _temperature;
            set
            {
                if(_temperature != value)
                {
                    _temperature = value;
                    // RAISE EVENT
                    OnTemperatureChanged(new TemperatureChangedEventArgs(value));
                }
            }
        }

        protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
        {
            // Letting every subscriber know!
            TemperatureChanged?.Invoke(this, e);
        }
    }

    public class TemperatureAlert
    {
        public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            Console.WriteLine($"Alert: temperature is {e.Temperature} sender is: {sender} ");
        }
    }

    public class TempCoolingAlert
    {
        public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            Console.WriteLine($"TEMP Cooling Alert: temperature is {e.Temperature} sender is: {sender} ");
        }
    }

    /*
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
    */

    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            EventPublisher publisher = new EventPublisher();
            EventSubscriber subscriber = new EventSubscriber();
            publisher.OnNotify += subscriber.OnEventRaised;

            publisher.RaiseEvent("This is a test event message.");
            */

            TemperatureMonitor monitor = new TemperatureMonitor();
            TemperatureAlert alert = new TemperatureAlert();
            TempCoolingAlert alert2 = new TempCoolingAlert();
            monitor.TemperatureChanged += alert.OnTemperatureChanged;
            monitor.TemperatureChanged += alert2.OnTemperatureChanged;

            monitor.Temperature = 32; // This will trigger the alert
            monitor.Temperature = 28; // This will not trigger the alert
        }
    }
}
