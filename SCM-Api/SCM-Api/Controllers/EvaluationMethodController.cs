namespace SCM_Api.Controllers
{
    using AutoMapper;
    using Common.Constant;
    using Common.Helpers;
    using Data.Entities;
    using Data.StoreProcedureModel;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contract;
    using Services.Models;
    using System.Net;
    using System.Text;
    using static Common.Helpers.Enum;

    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationMethodController : ControllerBase
    {
        private readonly IEvaluationMethodService _evaluationMethodService;
        private readonly IMapper _mapper;

        public EvaluationMethodController(IEvaluationMethodService evaluationMethodService, IMapper mapper)
        {
            _evaluationMethodService = evaluationMethodService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get the EvaluationMethod data by Id.
        /// </summary>
        /// <param name="evaluationMethodId"></param>
        /// <returns>The Api Response</returns>
        [HttpGet("GetById/{evaluationMethodId}")]
        public async Task<IActionResult> GetById(int evaluationMethodId)
        {
            EvaluationMethod? evaluationMethod = await _evaluationMethodService.GetById(evaluationMethodId);
            if (evaluationMethod == null)
            {
                return Ok(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"EvaluationMethod data not found." }, evaluationMethodId));
            }

            return Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, _mapper.Map<EvaluationMethodModel>(evaluationMethod)));
        }

        /// <summary>
        /// Save the new EvaluationMethod data.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The Api Response</returns>
        [HttpPost("AddEvaluationMethod")]
        public async Task<IActionResult> AddEvaluationMethod([FromForm] EvaluationMethodModel model)
        {
            EvaluationMethod evaluationMethod = _mapper.Map<EvaluationMethod>(model);
            if (model.ThresholdFrom < model.ThresholdTo)
            {
                int evaluationMethodId = await _evaluationMethodService.Save(evaluationMethod);
                return Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, evaluationMethodId));
            }

            return Ok(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { MessageConstant.RequestUnSuccessful, "ThresholdFrom must be less than ThresholdTo" }));
        }

        /// <summary>
        /// Update the EvaluationMethod data by Id.
        /// </summary>
        /// <param name="evaluationMethodId"></param>
        /// <param name="model"></param>
        /// <returns>The Api Response</returns>
        [HttpPut("UpdateEvaluationMethod/{evaluationMethodId}")]
        public async Task<IActionResult> UpdateEvaluationMethod(int evaluationMethodId, [FromForm] EvaluationMethodModel model)
        {
            EvaluationMethod? oldEvaluationMethod = await _evaluationMethodService.GetById(evaluationMethodId);
            if (oldEvaluationMethod != null && oldEvaluationMethod.StatusId != (byte)GeneralStatuses.Delete)
            {
                EvaluationMethod evaluationMethod = _mapper.Map<EvaluationMethod>(model);
                if (model.ThresholdFrom < model.ThresholdTo)
                {
                    evaluationMethod.EvaluationMethodId = (int)evaluationMethodId;
                    evaluationMethod.CreatedDate = oldEvaluationMethod.CreatedDate;
                    await _evaluationMethodService.Update(evaluationMethod);
                    return Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, evaluationMethodId));
                }
                else
                {
                    return Ok(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { MessageConstant.RequestUnSuccessful, "ThresholdFrom must be less than ThresholdTo" }));
                }
            }
            else
            {
                return Ok(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"Evuluation Method data not found." }, evaluationMethodId));
            }
        }

        /// <summary>zz
        /// Delete EvaluationMethod data by Id.
        /// </summary>
        /// <param name="evaluationMethodId"></param>
        /// <returns>The Api Response</returns>
        [HttpDelete("DeleteEvaluationMethod/{evaluationMethodId}")]
        public async Task<IActionResult> DeleteEvaluationMethod(int evaluationMethodId)
        {
            EvaluationMethod? evaluationMethod = await _evaluationMethodService.GetById(evaluationMethodId);
            if (evaluationMethod != null && evaluationMethod.StatusId != (byte)GeneralStatuses.Delete)
            {
                return Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, await _evaluationMethodService.Delete(evaluationMethod)));
            }
            else
            {
                return Ok(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"Evuluation Method data not found." }, evaluationMethodId));
            }
        }

        /// <summary>
        /// Get The next thresholdFrom value
        /// </summary>
        /// <returns>The next thresholdFrom value</returns>
        [HttpGet("GetNextThresholdFrom")]
        public async Task<IActionResult> GetNextThresholdFrom()
        {
            decimal nextThresholdFrom = await _evaluationMethodService.GetMaxThresholdFromValue();
            return Ok(nextThresholdFrom);
        }

        /// <summary>
        /// Get the list of EvaluationMethod with filter, sorting and pagination.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>The Api Response</returns>
        [HttpPost("GetEvaluationMethodList")]
        public async Task<IActionResult> GetEvaluationMethodList([FromForm] SP_EvaluationMethodFilterModel filter) =>
          Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, await _evaluationMethodService.GetEvaluationMethodList(filter)));

        /// <summary>
        /// Convert the EvaluationMethod list to CSV.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>The Api Response</returns>
        [HttpPost("ConvertToCsv")]
        public async Task<IActionResult> ConvertToCsv([FromForm] SP_EvaluationMethodFilterModel filter)
        {
            IEnumerable<SP_EvaluationMethodListModel>? listOfEvaluationMethod = await _evaluationMethodService.GetEvaluationMethodList(filter);
            return new FileContentResult(Encoding.ASCII.GetBytes(Helper.ConvertToCSV(listOfEvaluationMethod.ToList())), "text/csv");
        }
    }
}
