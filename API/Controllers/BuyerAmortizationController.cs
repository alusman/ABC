using ABC.Core.Interfaces.Services;
using ABC.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuyerAmortizationController : Controller
    {
        private readonly IBuyerInfoService _buyerInfoService;
        private readonly IAmortizationScheduleService _amortizationScheduleService;
        public BuyerAmortizationController(IBuyerInfoService buyerInfoService, IAmortizationScheduleService amortizationScheduleService)
        {
            _buyerInfoService = buyerInfoService ?? throw new ArgumentNullException($"{nameof(buyerInfoService)} is required");
            _amortizationScheduleService = amortizationScheduleService ?? throw new ArgumentNullException($"{nameof(amortizationScheduleService)} is required");
        }

        /// <summary>
        /// Gets the list of buyer info and unit
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetBuyerInfoList")]
        [ProducesResponseType(typeof(IEnumerable<BuyerInfo>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllBuyerInfo()
        {
            var result = await _buyerInfoService.GetAllBuyerInfo().ConfigureAwait(false);
            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Gets buyer info and unit by ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetBuyerInfoByID")]
        [ProducesResponseType(typeof(BuyerInfo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBuyerInfo(Guid id)
        {
            var result = await _buyerInfoService.GetBuyerInfoById(id).ConfigureAwait(false);
            if (result == null) return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Gets the amortization schedule for the give buyer info ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}/schedule", Name = "GetAmortizationScheduleByBuyerInfoID")]
        [ProducesResponseType(typeof(IEnumerable<AmortizationSchedule>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSchedule(Guid id)
        {
            var result = await _amortizationScheduleService.GetAmortizationScheduleByBuyerInfoId(id).ConfigureAwait(false);
            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}
