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
        /// <param name="id">Buyer info ID</param>
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
        /// <param name="id">Buyer info ID</param>
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

        /// <summary>
        /// Saves buyer info to the database
        /// </summary>
        /// <returns></returns>
        [HttpPost("savebuyerinfo", Name = "InsertBuyerInfo")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SaveBuyerInfo([FromBody] BuyerInfo model)
        {
            var result = await _buyerInfoService.SaveBuyerInfo(model).ConfigureAwait(false);
            if (result == null) return BadRequest();

            return Ok(result);
        }

        /// <summary>
        /// Update buyer info to the database
        /// </summary>
        /// <returns></returns>
        [HttpPut("updatebuyerinfo", Name = "UpdateBuyerInfo")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBuyerInfo([FromBody] BuyerInfo model)
        {
            var result = await _buyerInfoService.UpdateBuyerInfo(model).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        /// Update buyer info to the database
        /// </summary>
        /// <param name="id">Buyer info ID</param>
        /// <returns></returns>
        [HttpDelete("delete/{id}", Name = "DeleteBuyerInfo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBuyerInfo(Guid id)
        {
            await _amortizationScheduleService.DeleteSchedule(id).ConfigureAwait(false);
            await _buyerInfoService.DeleteBuyerInfo(id).ConfigureAwait(false);
            
            return Ok();
        }

        /// <summary>
        /// Generates amortization schedule based on buyer info
        /// </summary>
        /// <returns></returns>
        [HttpPost("createschedule", Name = "BuildAmortizationSchedule")]
        [ProducesResponseType(typeof(IEnumerable<AmortizationSchedule>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAmortizationSchedule([FromBody] BuyerInfo model)
        {
            var buyerInfoId = model.Id;

            if (buyerInfoId == Guid.Empty)
            {
                buyerInfoId = await _buyerInfoService.SaveBuyerInfo(model).ConfigureAwait(false);
                if (buyerInfoId == null) return BadRequest();

                model.Id = buyerInfoId;
            }
                
            var result = await _amortizationScheduleService.CreateSchedule(model).ConfigureAwait(false);
            if (result == null) return BadRequest();

            return Ok(result);
        }

        /// <summary>
        /// Delete amortization schedule
        /// </summary>
        /// <param name="id">Buyer info ID</param>
        /// <returns></returns>
        [HttpDelete("deleteschedule/{id}", Name = "DeleteAmortizationSchedule")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAmortizationSchedule(Guid id)
        {
            await _amortizationScheduleService.DeleteSchedule(id).ConfigureAwait(false);

            return Ok();
        }
    }
}
