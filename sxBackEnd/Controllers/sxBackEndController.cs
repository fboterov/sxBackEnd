using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sxBackEnd.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace sxBackEnd.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class sxBackEndController : ControllerBase
    {
        private readonly ILogger<sxBackEndController> _logger;
        private readonly IMembersService _membersService;

        public sxBackEndController(ILogger<sxBackEndController> logger, IMembersService membersService)
        {
            _membersService = membersService;
            _logger = logger;
            _logger.LogInformation("CONTROLLER START => sxBackEndController");
        }

        [HttpGet]
        public ActionResult<List<Member>> GetMemberRecords(long? mcn, long? pn)
        {
            _logger.LogInformation("CALL TO > GetMemberRecords()");

            var result = _membersService.GetMemberRecords(mcn, pn);

            _logger.LogInformation($"CALL TO > GetMemberRecords FoundRecords[{result.Any()}]");

            if (!result.Any()) {
                return NotFound();
            }

            return new ObjectResult(result)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
