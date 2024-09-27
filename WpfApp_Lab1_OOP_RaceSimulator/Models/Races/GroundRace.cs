using System;

namespace WpfApp_Lab1_OOP_RaceSimulator.Models.Races
{
    public class GroundRace : Race
    {
        public GroundRace(double distance) : base(distance) { }
        public override void RegisterTransport(ITransport transport)
        {
            if (transport is GroundTransport)
                Participants.Add(transport);
            else
                throw new InvalidOperationException("Нельзя зарегистрировать не наземное транспортное средство на наземную гонку");
        }
    }
}
