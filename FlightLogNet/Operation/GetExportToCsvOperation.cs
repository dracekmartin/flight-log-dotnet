namespace FlightLogNet.Operation
{
    using System.Text;
    using Repositories.Interfaces;

    public class GetExportToCsvOperation(IFlightRepository flightRepository)
    {
        public byte[] Execute()
        {
            // TODO 5.1: Naimplementujte export do CSV
            // TIP: CSV soubor je pouze string, který se dá vytvořit pomocí třídy StringBuilder
            // TIP: Do bytové reprezentace je možné jej převést například pomocí metody: Encoding.UTF8.GetBytes(..)

            StringBuilder sb = new();

            foreach(var flight in flightRepository.GetAllFlights())
            {
                sb.AppendLine(string.Join(";",flight.Id.ToString(),
                    flight.TakeoffTime.ToString(),
                    flight.LandingTime.ToString(),
                    flight.Airplane.Id.ToString(),
                    flight.Pilot.FirstName.ToString(),
                    flight.Pilot.LastName.ToString(),
                    flight.Pilot.MemberId.ToString(),
                    flight.Copilot?.FirstName.ToString(),
                    flight.Copilot?.LastName.ToString(),
                    flight.Copilot?.MemberId.ToString(),
                    flight.Task));
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}
