using Microsoft.AspNetCore.Mvc;
using NUnitTest.Interfaces;
using NUnitTest.Models;

namespace NUnitTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JuiceController : Controller
    {
        private readonly ILogger<JuiceController> _logger;
        private readonly IJuiceHandler _juiceHandler;

        public JuiceController(ILogger<JuiceController> logger, IJuiceHandler juiceHandler)
        {
            _logger = logger;
            _juiceHandler = juiceHandler;
        }

        [HttpGet]
        public Juice Get(int NoOfPeople, int NoOfPeopleNotInterested)
        {
            var order = new Order { NoOfPeople = NoOfPeople, NoOfPeopleNotInterested = NoOfPeopleNotInterested };
            _juiceHandler.CreateNewJuice(order);
            return _juiceHandler.GetJuice();
        }
    }
}
