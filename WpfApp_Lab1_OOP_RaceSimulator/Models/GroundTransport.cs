namespace WpfApp_Lab1_OOP_RaceSimulator.Models
{
    public abstract class GroundTransport : ITransport
    {
        public abstract string Name { get; }
        public abstract double Speed { get; }
        public abstract double RestInterval { get; }
        public abstract double CalculateRestDuration(int restCount);

        public double CalculateTime(double distance)
        {
            double time = 0;
            double traveledDistance = 0;
            int restCount = 0;

            while (traveledDistance < distance)
            {
                double nextRestDistance = Speed * RestInterval;
                double remainingDistance = distance - traveledDistance;

                if (remainingDistance < nextRestDistance)
                {
                    time += remainingDistance / Speed;
                    traveledDistance += remainingDistance;
                    break;
                }

                traveledDistance += nextRestDistance;
                time += RestInterval;
                restCount++;
                time += CalculateRestDuration(restCount);
            }
            return time;
        }
    }
}