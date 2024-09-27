namespace WpfApp_Lab1_OOP_RaceSimulator.Models.GroundTransports
{
    class Centaur : GroundTransport
    {
        public override string Name => "Кентавр";
        public override double Speed => 100.0;
        public override double RestInterval => 400.0;
        public override double CalculateRestDuration(int restCount)
        {
            return restCount / 2 == 0 ? 5 : 10;
        }
    }
}
