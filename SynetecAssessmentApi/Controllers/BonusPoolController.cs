using System;
using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SynetecAssessmentApi.Services.Interfaces;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusPoolController : Controller
    {
        private readonly IBonusPoolService _bonusPoolService;

        public BonusPoolController(IBonusPoolService bonusPoolService)
        {
            _bonusPoolService = bonusPoolService;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost(Name = "CalculateBonus"), Consumes("application/json")]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            try
            {
                return Ok(await _bonusPoolService.CalculateBonus(
                    request.TotalBonusPoolAmount,
                    request.SelectedEmployeeId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Unable to calculate bonus: {ex}");
            }
        }
    }
}