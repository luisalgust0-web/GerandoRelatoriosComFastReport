using Microsoft.AspNetCore.Mvc;
using RelatoriosComFastReport.Context.Repository;
using RelatoriosComFastReport.Models;

namespace RelatoriosComFastReport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        public GeneralRepository _repository;
        public HomeController(GeneralRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetTrips")]
        public List<Trips> GetTrips()
        {
            return _repository.GetAllTrips();
        }

        [HttpGet("GetUsers")]
        public List<User> GetUsers()
        {
            return _repository.GetAllUsers();
        }

    }
}