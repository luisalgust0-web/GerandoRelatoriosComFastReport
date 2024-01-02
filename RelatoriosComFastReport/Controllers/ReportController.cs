using FastReport;
using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Mvc;
using RelatoriosComFastReport.Models;
using RelatoriosComFastReport.Repository.Interfaces;
using System.Drawing;

namespace RelatoriosComFastReport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnv;
        private readonly ITripRepository _tripRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserTripRelationshipRepository _userTripRelationshipRepository;

        public ReportController(IWebHostEnvironment webHostEnv, ITripRepository tripRepository, IUserRepository userRepository, IUserTripRelationshipRepository userTripRelationshipRepository)
        {
            _webHostEnv = webHostEnv;
            _tripRepository = tripRepository;
            _userRepository = userRepository;
            _userTripRelationshipRepository = userTripRelationshipRepository;
        }

        [HttpGet("CreateReportFrx")]
        public IActionResult CreateReport()
        {
            string reportFile = Path.Combine(_webHostEnv.ContentRootPath, @"reports\UserTripRelationshipReport.frx");

            Report fReport = new Report();

            List<UserTripRelationship> userTripRelationships = _userTripRelationshipRepository.GetUsersTripRelationship();

            
            fReport.Dictionary.RegisterBusinessObject(userTripRelationships, "userTripRelationships", 10, true);
            fReport.Report.Save(reportFile);

            return Ok($"Caminho Report.Frx : {reportFile}");
        }

        [HttpGet("GenerateTripReport")]
        public IActionResult GenerateTripReport()
        {
            string reportFile = Path.Combine(_webHostEnv.ContentRootPath, @"reports\TripReport.frx");

            Report fReport = new Report();

            List<Trip> trips = _tripRepository.GetAllTrips();

            fReport.Report.Load(reportFile);
            fReport.Dictionary.RegisterBusinessObject(trips, "tripList", 10, true);
            fReport.Prepare();
            PDFSimpleExport pdfExport = new PDFSimpleExport();

            using MemoryStream memoryStream = new MemoryStream();
            pdfExport.Export(fReport, memoryStream);
            memoryStream.Flush();
            return File(memoryStream.ToArray(), "application/pdf", Path.GetFileNameWithoutExtension("TripReport") + ".pdf");
        }

        [HttpGet("GenerateUserReport")]
        public IActionResult GenerateUserReport()
        {
            string reportFile = Path.Combine(_webHostEnv.ContentRootPath, @"reports\UserReport.frx");

            Report fReport = new Report();

            List<User> user = _userRepository.GetAllUsers();

            fReport.Report.Load(reportFile);
            fReport.Dictionary.RegisterBusinessObject(user, "userList", 10, true);
            fReport.Prepare();
            PDFSimpleExport pdfExport = new PDFSimpleExport();

            using MemoryStream memoryStream = new MemoryStream();
            pdfExport.Export(fReport, memoryStream);
            memoryStream.Flush();
            return File(memoryStream.ToArray(), "application/pdf", Path.GetFileNameWithoutExtension("UserReport") + ".pdf");
        }

        [HttpGet("GenerateUserTripRelationshipReport")]
        public IActionResult GenerateUserTripRelationshipReport()
        {
            string reportFile = Path.Combine(_webHostEnv.ContentRootPath, @"reports\UserTripRelationshipReport.frx");

            Report fReport = new Report();

            List<UserTripRelationship> userTripRelationships = _userTripRelationshipRepository.GetUsersTripRelationship();

            fReport.Report.Load(reportFile);
            fReport.Dictionary.RegisterBusinessObject(userTripRelationships, "userTripRelationships", 10, true);
            fReport.Prepare();
            PDFSimpleExport pdfExport = new PDFSimpleExport();

            using MemoryStream memoryStream = new MemoryStream();
            pdfExport.Export(fReport, memoryStream);
            memoryStream.Flush();
            return File(memoryStream.ToArray(), "application/pdf", Path.GetFileNameWithoutExtension("UserTripRelationshipReport") + ".pdf");
        }
    }
}
