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
    public class MethodsController : ControllerBase
    {
        private readonly IMethodsService _methodsService;

        public MethodsController(IMethodsService methodsService)
        {
            _methodsService = methodsService;
        }

        /// <summary>
        /// Get all methods
        /// </summary>
        /// <returns></returns>
        /// <response code="200">All methods have been successfully retrieved</response>
        /// <response code="404">Methods could not be retrieved from the database</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<MethodModel>>> GetAllAsync()
        {
            ICollection<MethodModel> result = await _methodsService.GetAllMethodsAsync();
            if (result == null)
                return NotFound(new ProblemDetails() {Detail = "Methods could not be retrieved"});
            return Ok(result);
        }

        /// <summary>
        /// Get specific method
        /// </summary>
        /// <param name="id">ID of the specified method</param>
        /// <returns></returns>
        /// <response code="200">Information about the specified method has been successfully retrieved</response>
        /// <response code="404">Specified method was not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MethodModel>> GetMethodAsync([FromRoute] int id)
        {
            return Ok(await _methodsService.GetByIdAsync(id));
        }

        /// <summary>
        /// Get steps for the specified method
        /// </summary>
        /// <param name="methodId">ID of the specified method</param>
        /// <returns></returns>
        /// <response code="200">Information about steps has been successfully retrieved</response>
        /// <response code="404">Specified method was not found</response>
        [HttpGet("{methodId:int}/steps")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<StepModel>>> GetStepsByMethodAsync([FromRoute] int methodId)
        {
            return Ok(await _methodsService.GetStepsByMethodAsync(methodId));
        }
    }
}
