namespace WpfApp_Lab1_OOP_RaceSimulator.Models.AirTransports
{
    internal class BabaYagaStupa : AirTransport
    {
        public override string Name => "Ступа Бабы-Яги";
        public override double Speed => 50.0;
        public override double AccelerationFactor(double distance)
        {
            return 1.25;
        }
    }
}
