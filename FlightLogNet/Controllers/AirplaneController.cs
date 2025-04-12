namespace FlightLogNet.Controllers
{
    using System.Collections.Generic;
    using Facades;
    using FlightLogNet.Models;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [EnableCors]
    [Route("[controller]")]
    public class AirplaneController : ControllerBase
    {
        // TODO 3.1: Vystavte REST HTTPGet metodu vracející seznam klubových letadel
        // Letadla získáte voláním airplaneFacade
        // dotazované URL je /airplane
        // Odpověď by měla být kolekce AirplaneModel

        private readonly ILogger<AirplaneController> logger;
        private readonly AirplaneFacade airplaneFacade;

        public AirplaneController(ILogger<AirplaneController> logger, AirplaneFacade airplaneFacade)
        {
            this.logger = logger;
            this.airplaneFacade = airplaneFacade;
        }

        [HttpGet]
        public IEnumerable<AirplaneModel> GetAllPlanes()
        {
            logger.LogDebug("GetAllPlanes");
            return airplaneFacade.GetClubAirplanes();
        }
    }
}
