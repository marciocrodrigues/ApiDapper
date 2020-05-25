using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiDapper.Api.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("error")]
        public string Get()
        {
           _logger.LogInformation($"TESTE LOGGER");
           return "TESTE LOGGE";
        }
    }
}