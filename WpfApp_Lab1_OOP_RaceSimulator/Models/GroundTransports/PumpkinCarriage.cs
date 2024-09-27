using System;

namespace WpfApp_Lab1_OOP_RaceSimulator.Models.GroundTransports
{
    class PumpkinCarriage : GroundTransport
    {
        public override string Name => "Карета-тыква";
        public override double Speed => 60.0;
        public override double RestInterval => 500.0;
        public override double CalculateRestDuration(int restCount)
        {
            return Math.Max(30.0 - (restCount * 5), 5.0);
        }
    }
}
