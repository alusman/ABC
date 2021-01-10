using ABC.Core.Models;
using ABC.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPA.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuyerAmortizationController : Controller
    {
        private readonly IBuyerAmortizationService _service;
        private readonly IMapper _mapper;
        public BuyerAmortizationController(IBuyerAmortizationService service, IMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException($"{nameof(service)} is required");
            _mapper = mapper ?? throw new ArgumentNullException($"{nameof(service)} is required");
        }

        /// <summary>
        /// Gets the list of buyer info and unit
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetBuyerInfoList")]
        [ProducesResponseType(typeof(IEnumerable<BuyerInfoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllBuyerInfo()
        {
            var result = await _service.GetAllBuyerInfo().ConfigureAwait(false);
            if (result == null) return NotFound();

            return Ok(_mapper.Map<BuyerInfoDTO[]>(result));
        }

        /// <summary>
        /// Gets buyer info and unit by ID
        /// </summary>
        /// <param name="id">Buyer info ID</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetBuyerInfoByID")]
        [ProducesResponseType(typeof(BuyerInfoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBuyerInfo(Guid id)
        {
            var result = await _service.GetBuyerInfoById(id).ConfigureAwait(false);
            if (result == null) return NotFound();

            return Ok(_mapper.Map<BuyerInfoDTO>(result));
        }

        /// <summary>
        /// Gets the amortization schedule for the give buyer info ID
        /// </summary>
        /// <param name="id">Buyer info ID</param>
        /// <returns></returns>
        [HttpGet("{id}/schedule", Name = "GetAmortizationScheduleByBuyerInfoID")]
        [ProducesResponseType(typeof(IEnumerable<AmortizationScheduleDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSchedule(Guid id)
        {
            var result = await _service.GetAmortizationScheduleByBuyerInfoId(id).ConfigureAwait(false);
            if (result == null) return NotFound();

            return Ok(_mapper.Map<AmortizationScheduleDTO[]>(result));
        }

        /// <summary>
        /// Saves buyer info to the database
        /// </summary>
        /// <returns></returns>
        [HttpPost("savebuyerinfo", Name = "InsertBuyerInfo")]
        [ProducesResponseType(typeof(BuyerInfoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SaveBuyerInfo([FromBody]BuyerInfo model)
        {
            var result = await _service.SaveBuyerInfo(model).ConfigureAwait(false);
            if (result == null) return BadRequest();

            return Ok(_mapper.Map<BuyerInfoDTO>(result));
        }

        /// <summary>
        /// Update buyer info to the database
        /// </summary>
        /// <returns></returns>
        [HttpPut("updatebuyerinfo", Name = "UpdateBuyerInfo")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBuyerInfo([FromBody]BuyerInfo model)
        {
            var result = await _service.UpdateBuyerInfo(model).ConfigureAwait(false);

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
            await _service.DeleteBuyerInfo(id).ConfigureAwait(false);
            
            return Ok();
        }

        /// <summary>
        /// Generates amortization schedule based on buyer info
        /// </summary>
        /// <returns></returns>
        [HttpPost("createschedule", Name = "BuildAmortizationSchedule")]
        [ProducesResponseType(typeof(IEnumerable<AmortizationScheduleDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAmortizationSchedule([FromBody]BuyerInfo model)
        {
            var result = await _service.CreateAmortizationSchedule(model).ConfigureAwait(false);
            if (result == null) return BadRequest();

            return Ok(_mapper.Map<AmortizationScheduleDTO[]>(result));
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
            await _service.DeleteAmortizationSchedule(id).ConfigureAwait(false);

            return Ok();
        }
    }
}
