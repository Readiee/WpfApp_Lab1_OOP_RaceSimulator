using System;

namespace WpfApp_Lab1_OOP_RaceSimulator.Models.AirTransports
{
    internal class FlyingShip : AirTransport
    {
        public override string Name => "Летучий Корабль";
        public override double Speed => 60.0;
        public override double AccelerationFactor(double distance)
        {
            return Math.Min(1.25 + (distance / 1000.0), 3);
        }
    }
}
