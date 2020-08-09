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
    public class StepsController : ControllerBase
    {
        private readonly IStepsService _stepsService;

        public StepsController(IStepsService stepsService)
        {
            _stepsService = stepsService;
        }

        /// <summary>
        /// Get all steps
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Information about all steps has been successfully retrieved</response>
        /// <response code="404">Information about steps could not be retrieved</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<StepModel>>> GetAllAsync()
        {
            return Ok(await _stepsService.GetAllAsync());
        }
        
        /// <summary>
        /// Get specific step
        /// </summary>
        /// <param name="id">ID of the specified step</param>
        /// <returns></returns>
        /// <response code="200">Information about the specified step has been successfully retrieved</response>
        /// <response code="404">Specified step was not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StepModel>> GetStepAsync([FromRoute] int id)
        {
            StepModel stepModel = await _stepsService.GetByIdAsync(id);
            if (stepModel == null)
                return NotFound(new {Message = $"Step with id {id} was not found"});

            return Ok(stepModel);
        }

        /// <summary>
        /// Get cases for specific step
        /// </summary>
        /// <param name="stepId">ID of the specified step</param>
        /// <returns></returns>
        /// <response code="200">Information about the cases has been successfully retrieved</response>
        /// <response code="404">Specified step was not found</response>
        [HttpGet("{stepId:int}/cases")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<CaseModel>>> GetCasesByStepAsync([FromRoute] int stepId)
        {
            ICollection<CaseModel> caseModels = await _stepsService.GetCasesByStepAsync(stepId);
            if (caseModels == null)
                return NotFound(new {Message = $"Step with id {stepId} was not found"});

            return Ok(caseModels);
        }

        /// <summary>
        /// Get methods that include specific step
        /// </summary>
        /// <param name="stepId">ID of the specified step</param>
        /// <returns></returns>
        /// <response code="200">Information about the methods has been successfully retrieved</response>
        /// <response code="404">Specified step was not found</response>
        [HttpGet("{stepId:int}/methods")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<MethodModel>>> GetMethodsByStepAsync([FromRoute] int stepId)
        {
            ICollection<MethodModel> methodModels = await _stepsService.GetMethodsByStepAsync(stepId);

            if (methodModels == null)
                return NotFound(new { Message = $"Step with id {stepId} was not found" });

            return Ok(methodModels);
        }
    }
}
