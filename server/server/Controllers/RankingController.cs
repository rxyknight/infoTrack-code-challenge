using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Interfaces;

namespace server.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableCors]
    public class RankingController : ControllerBase
    {
        private IRankingService _rankingService;
        public RankingController(IRankingService rankingService)
        {
            _rankingService = rankingService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string keywords, [FromQuery] string url, [FromQuery] string searchEngines)
        {
            try
            {
                var engineTypes = new List<string>(searchEngines.Split(","));
                return Ok(_rankingService.GetRankingResult(keywords, url, engineTypes));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return StatusCode(500);
        }
    }
}