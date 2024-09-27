using System;

namespace WpfApp_Lab1_OOP_RaceSimulator.Models.Races
{
    public class AirRace : Race
    {
        public AirRace(double distance) : base(distance) { }
        public override void RegisterTransport(ITransport transport)
        {   
            if (transport is AirTransport)
                Participants.Add(transport);
            else
                throw new InvalidOperationException("Нельзя зарегистрировать не воздушное транспортное средство на воздушную гонку");
        }
    }
}
