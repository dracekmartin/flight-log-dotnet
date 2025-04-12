namespace FlightLogNet.Repositories.Interfaces
{
    using System.Collections.Generic;

    using Models;

    public interface IFlightRepository
    {
        IList<ReportModel> GetReport();

        IList<FlightModel> GetAllFlightsInAir();

        void LandFlight(FlightLandingModel landingModel);

        void TakeoffFlight(long? gliderFlightId, long? towplaneFlightId);

        long CreateFlight(CreateFlightModel model);

        IList<FlightModel> GetFlightsOfType(FlightType type);

        IList<FlightModel> GetAllFlights();
    }
}
