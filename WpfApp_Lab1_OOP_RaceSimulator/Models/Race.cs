using System.Collections.Generic;
using System.Linq;

namespace WpfApp_Lab1_OOP_RaceSimulator.Models
{
    public abstract class Race
    {
        public Race(double distance)
        {
            Distance = distance;
            Participants = new List<ITransport>();
        }
        public double Distance { get; set; }
        public List<ITransport> Participants { get; }

        public abstract void RegisterTransport(ITransport transport);
        public List<RaceResult> StartRace()
        {
            return Participants
                .Select(p => new RaceResult(p.Name, p.CalculateTime(Distance)))
                .OrderBy(result => result.Time)
                .ToList();
        }
    }

    public class RaceResult
    {
        public RaceResult(string name, double time)
        {
            Name = name;
            Time = time;
        }
        public string Name { get; }
        public double Time { get; }
    }
}
