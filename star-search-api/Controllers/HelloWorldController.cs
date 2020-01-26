using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;


namespace star_search_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(ILogger<HelloWorldController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public HelloWorld Get(String artist, DateTime StartDate, DateTime EndDate, int location, int MaxDistance, int MaxPrice, String vendor)
        {
            // TODO: Determine Validations and Response messaging
            
            // Enforce default values for StartDate and EndDate
            // StartDate defaults to DateTime.Now if not sent
            // StartDate has a minimum value of DateTime.Now
            StartDate = StartDate < DateTime.Now ? DateTime.Now : StartDate;
            // EndDate defaults to DateTime.Now plus 1 year
            // EndDate must be greater than or equal to StartDate
            EndDate = EndDate < StartDate ? StartDate.AddYears(1) : EndDate;
            return new HelloWorld
            {
                Artist = artist,
                StartDate = StartDate,
                EndDate = EndDate,
                Location = location,
                MaxDistance = MaxDistance,
                MaxPrice = MaxPrice,
                Vendor = vendor
            };
        }
    }
}