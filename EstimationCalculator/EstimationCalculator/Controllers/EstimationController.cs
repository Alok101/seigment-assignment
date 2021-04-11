using Business.Contracts.Interface;
using Business.Contracts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstimationCalculator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstimationController : ControllerBase
    {
        private readonly IEstimationService _estimationService;
        public EstimationController(IEstimationService estimationService)
        {
            _estimationService = estimationService;
        }
        [HttpPost, Route("print"), Authorize]
        public IActionResult Print(string actionType, [FromBody] CustomerItemViewModel purchaseItem)
        {
            if (actionType == "file")
            {
                _estimationService.PrintToFile(purchaseItem);
            }
            else
            {
                _estimationService.PrintToPaper();
            }

            return Ok(true);
        }
    }
}
