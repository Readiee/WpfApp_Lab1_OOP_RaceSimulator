namespace WpfApp_Lab1_OOP_RaceSimulator.Models.Races
{
    public class MixedRace : Race
    {
        public MixedRace(double distance) : base(distance) { }
        public override void RegisterTransport(ITransport transport)
        {
            Participants.Add(transport);
        }
    }
}
