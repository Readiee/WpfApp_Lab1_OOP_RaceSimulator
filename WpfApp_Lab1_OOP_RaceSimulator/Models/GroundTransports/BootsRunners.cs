namespace WpfApp_Lab1_OOP_RaceSimulator.Models.GroundTransports
{
    class BootsRunners : GroundTransport
    {
        public override string Name => "Сапоги-схороходы";
        public override double Speed => 100.0;
        public override double RestInterval => 350.0;
        public override double CalculateRestDuration(int restCount)
        {
            return 10.0 * restCount;
        }
    }
}
