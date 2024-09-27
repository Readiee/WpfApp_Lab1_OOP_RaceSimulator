using System;

namespace WpfApp_Lab1_OOP_RaceSimulator.Models.GroundTransports
{
    class HutOnChickenLegs : GroundTransport
    {
        public override string Name => "Избушка на курьих ножках";
        public override double Speed => 80.0;
        public override double RestInterval => 100.0;
        public override double CalculateRestDuration(int restCount)
        {
            return Math.Pow(1, restCount);
        }
    }
}
