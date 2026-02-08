namespace Events
{
    public class Sensor
    {
        public event EventHandler<TemperatureEventArgs>? TemperatureChanged;
        private double _temperature;
        public void GetTemperature()
        {
            Random random = new Random();
            _temperature = random.Next(-20, 40);
            TemperatureChanged?.Invoke(this, new TemperatureEventArgs(_temperature));
        }

        public async Task MonitoringTemperature()
        {
            while (true)
            {
                GetTemperature();
                await Task.Delay(5000);
            }
        }
    }

    public class TemperatureEventArgs : EventArgs
    {
        public double Temperature { get; }

        public TemperatureEventArgs(double temperature)
        {
            Temperature = temperature;
        }
    }

    public class TemperatureWindow
    {
        public int Id;
        Sensor _sensor;
        public TemperatureWindow(Sensor termometer, int id)
        {
            Id = id;
            _sensor = termometer;
            _sensor.TemperatureChanged += OnTemperatureChanged;
            Id = id;
        }

        private void OnTemperatureChanged(object? sender, TemperatureEventArgs e)
        {
            Console.WriteLine($"[ID {Id}] Temperature: {e.Temperature}");
        }

    }

    public class TemperatureService
    {
        private Sensor _sensor;


        public TemperatureService(Sensor sensor)
        {
            _sensor = sensor;
        }

        public void GetTemperature()
        {
            _sensor.GetTemperature();
        }

        public void CreateTemperatureWindow(int id)
        {
            new TemperatureWindow(_sensor, id);
            Console.WriteLine("Вікно температури створено");
            GetTemperature();
        }

    }

    public class ExampleBad
    {
        public void Example()
        {
            Sensor sensor = new Sensor();
            TemperatureService temperatureService = new TemperatureService(sensor);

            temperatureService.CreateTemperatureWindow(1);

            Console.WriteLine("===================");

            temperatureService.CreateTemperatureWindow(2);

            Console.WriteLine("===================");

            temperatureService.CreateTemperatureWindow(3);
        }
    }

}
