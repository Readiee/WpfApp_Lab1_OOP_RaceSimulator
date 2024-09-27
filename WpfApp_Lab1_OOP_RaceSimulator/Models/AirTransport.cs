namespace WpfApp_Lab1_OOP_RaceSimulator.Models
{
    public abstract class AirTransport : ITransport
    {
        public abstract string Name { get; }
        public abstract double Speed { get; }
        public abstract double AccelerationFactor(double distance);
        public double CalculateTime(double distance)
        {
            return distance / (Speed * AccelerationFactor(distance));
            
            // double currentSpeed = Speed;
            // double time = 0;
            // double traveledDistance = 0;
            //
            // while (traveledDistance < distance)
            // {
            //     if (traveledDistance + currentSpeed >= distance)
            //     {
            //         time += (distance - traveledDistance) / currentSpeed;
            //         break;
            //     }
            //     traveledDistance += currentSpeed;
            //     time += 1;
            //     currentSpeed += AccelerationFactor(traveledDistance);
            // }
            // return time;
        }
    }
}