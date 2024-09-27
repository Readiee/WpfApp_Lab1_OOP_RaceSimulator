using System;

namespace WpfApp_Lab1_OOP_RaceSimulator.Models.AirTransports
{
    internal class CarpetPlane : AirTransport
    {
        public override string Name => "Ковер-самолет";
        public override double Speed => 100.0;
        public override double AccelerationFactor(double distance)
        {
            return Math.Min(1.25 + (distance / 5000.0), 1.75);
        }
    }
}
