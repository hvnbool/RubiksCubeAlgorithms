using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RubiksCubeAlgorithms.Models;
using RubiksCubeAlgorithms.WebApi.Services.Interfaces;

namespace RubiksCubeAlgorithms.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly ICasesService _casesService;
        private readonly IImagesService _imagesService;

        public CasesController(ICasesService casesService, IImagesService imagesService)
        {
            _casesService = casesService;
            _imagesService = imagesService;
        }

        /// <summary>
        /// Get all cases
        /// </summary>
        /// <returns></returns>
        /// <response code="200">All cases have been successfully retrieved</response>
        /// <response code="404">Cases could not be retrieved from the database</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CaseModel>>> GetAllAsync()
        {
            ICollection<CaseModel> result = await _casesService.GetAllAsync();
            if (result == null)
                return NotFound(new ProblemDetails { Detail = $"Cases could not be retrieved"});
            return Ok(result);
        }

        /// <summary>
        /// Get information about specific case
        /// </summary>
        /// <param name="id">ID of the specific case</param>
        /// <returns></returns>
        /// <response code="200">Information has been successfully retrieved</response>
        /// <response code="404">Specified case was not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CaseModel>> GetCaseAsync([FromRoute] int id)
        {
            CaseModel caseModel = await _casesService.GetByIdAsync(id);
            if (caseModel == null)
                return NotFound(new {Message = $"Case with id {id} was not found"});

            return Ok(caseModel);
        }

        /// <summary>
        /// Get steps that included specified case
        /// </summary>
        /// <param name="caseId">ID of the specific case</param>
        /// <returns></returns>
        /// <response code="200">Information about the steps has been successfully retrieved</response>
        /// <response code="404">Specified case was not found</response>
        [HttpGet("{caseId:int}/steps")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<StepModel>>> GetStepsByCaseAsync([FromRoute] int caseId)
        {
            ICollection<StepModel> steps = await _casesService.GetStepsByCase(caseId);
            if (steps == null)
                return NotFound(new { Message = $"Case with id {caseId} was not found" });

            return Ok(steps);
        }

        /// <summary>
        /// Get algorithms that solve the specified case
        /// </summary>
        /// <param name="caseId">ID of the specific case</param>
        /// <returns></returns>
        /// <response code="200">Information about the algorithms has been successfully retrieved</response>
        /// <response code="404">Specified case was not found</response>
        [HttpGet("{caseId:int}/algorithms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<AlgorithmModel>>> GetAlgorithmsByCaseAsync([FromRoute] int caseId)
        {
            ICollection<AlgorithmModel> algorithms = await _casesService.GetAlgorithmsByCase(caseId);
            if (algorithms == null)
                return NotFound(new { Message = $"Case with id {caseId} was not found" });

            return Ok(algorithms);
        }
        
        /// <summary>
        /// Get image for specified case
        /// </summary>
        /// <param name="caseId">ID of case which image is requested</param>
        /// <returns>The image</returns>
        /// <response code="200">Image has been successfully retrieved</response>
        /// <response code="404">Case with specified ID was not found</response>
        [HttpGet("{caseId:int}/image")]
        public async Task<ActionResult> Download([FromRoute] int caseId)
        {
            try
            {
                string relativePath = (await _casesService.GetByIdAsync(caseId))?.ImageRelativePath;
                if (relativePath == null) throw new ArgumentNullException();
                
                byte[] fileBytes = await _imagesService.GetImage(relativePath);
                if (fileBytes == null)
                    return NotFound(new { Message = "Image with specified relative path was not found"});
                return File(
                    fileContents: fileBytes,
                    contentType: "image/png", //TODO: Generalize for all file (or at least image) types
                    fileDownloadName: relativePath.Split('/').Last());
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new {Message = "Could not retrieve image for specified case"});
            }
        }
    }
}
