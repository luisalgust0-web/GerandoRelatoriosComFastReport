using Microsoft.AspNetCore.Mvc;
using RelatoriosComFastReport.Models;
using RelatoriosComFastReport.Repository.Interfaces;

namespace RelatoriosComFastReport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        public ITripRepository _tripRepository;
        public IUserRepository _userRepository;

        public HomeController(ITripRepository tripRepository, IUserRepository userRepository)
        {
            _tripRepository = tripRepository;
            _userRepository = userRepository;
        }

        [HttpGet("CargasIniciais")]
        public void CargaIniciais()
        {
            _tripRepository.CargaTrip();
            _userRepository.CargaUsers();
        }

        [HttpGet("GetTrips")]
        public List<Trip> GetTrips()
        {
            return _tripRepository.GetAllTrips();
        }

        [HttpGet("GetUsers")]
        public List<User> GetUsers()
        {
            return _userRepository.GetAllUsers();
        }

    }
}