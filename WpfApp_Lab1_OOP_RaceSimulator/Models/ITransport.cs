namespace WpfApp_Lab1_OOP_RaceSimulator.Models
{
    public interface ITransport
    {
        string Name { get; }
        double Speed { get; }

        double CalculateTime(double distance);
    }
}
