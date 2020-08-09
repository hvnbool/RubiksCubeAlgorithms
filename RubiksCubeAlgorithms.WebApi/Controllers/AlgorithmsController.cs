using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RubiksCubeAlgorithms.Models;
using RubiksCubeAlgorithms.WebApi.Services.Interfaces;

namespace RubiksCubeAlgorithms.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlgorithmsController : ControllerBase
    {
        private readonly IAlgorithmsService _algorithmsService;

        public AlgorithmsController(IAlgorithmsService algorithmsService)
        {
            _algorithmsService = algorithmsService;
        }

        /// <summary>
        /// Get all algorithms
        /// </summary>
        /// <returns>Collection of all algorithms</returns>
        /// <response code="200">All algorithms were successfully retrieved from the database</response>
        /// <response code="404">The server could not retrieve algorithms</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<AlgorithmModel>>> GetAllAsync()
        {
            ICollection<AlgorithmModel> result = await _algorithmsService.GetAllAsync();
            if (result == null) return NotFound();
            return Ok(await _algorithmsService.GetAllAsync());
        }

        /// <summary>
        /// Get information about a specific algorithm
        /// </summary>
        /// <param name="id">ID of the specific algorithm</param>
        /// <returns></returns>
        /// <response code="200">Information about specified algorithm was successfully retrieved</response>
        /// <response code="404">Information about specified algorithm was not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AlgorithmModel>> GetByIdAsync([FromRoute] int id)
        {
            AlgorithmModel result = await _algorithmsService.GetByIdAsync(id);
            if (result == null)
                return NotFound(new ProblemDetails {Detail = $"Algorithm with id {id} was not found"});

            return Ok(result);
        }

        /// <summary>
        /// Get cases that are solved by specific algorithm
        /// </summary>
        /// <param name="algorithmId">ID of the specific algorithm</param>
        /// <returns></returns>
        /// <response code="200">The cases have been successfully retrieved</response>
        /// <response code="404">The algorithm with specified ID was not found</response>
        [HttpGet("{algorithmId:int}/cases")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<CaseModel>>> GetCasesByAlgorithm([FromRoute] int algorithmId)
        {
            ICollection<CaseModel> result = await _algorithmsService.GetCasesByAlgorithmAsync(algorithmId);
            if (result == null)
                return NotFound(new { MEssage = $"Algorithm with id {algorithmId} was not found" });

            return Ok(result);
        }
    }
}
