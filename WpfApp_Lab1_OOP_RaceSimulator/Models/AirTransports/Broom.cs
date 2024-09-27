using System;

namespace WpfApp_Lab1_OOP_RaceSimulator.Models.AirTransports
{
    internal class Broom : AirTransport
    {
        public override string Name => "Метла";
        public override double Speed => 80.0;
        public override double AccelerationFactor(double distance)
        {
            return 1.0 + Math.Log(distance + 1) / 100.0;
        }
    }
}
