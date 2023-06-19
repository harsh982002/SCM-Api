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
            var evaluationMethod = await _evaluationMethodService.GetById(evaluationMethodId);
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
        public async Task<IActionResult> AddEvaluationMethod(EvaluationMethodModel model)
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
        [HttpPost("UpdateEvaluationMethod/{evaluationMethodId}")]
        public async Task<IActionResult> UpdateEvaluationMethod(int evaluationMethodId, EvaluationMethodModel model)
        {
            EvaluationMethod? oldEvaluationMethod = await _evaluationMethodService.GetById(evaluationMethodId);
            if (oldEvaluationMethod != null && oldEvaluationMethod.DeletedDate == null)
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
        [HttpPost("DeleteEvaluationMethod/{evaluationMethodId}")]
        public async Task<IActionResult> DeleteEvaluationMethod(int evaluationMethodId)
        {
            EvaluationMethod? evaluationMethod = await _evaluationMethodService.GetById(evaluationMethodId);
            if (evaluationMethod != null && evaluationMethod.DeletedDate == null)
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
        public async Task<IActionResult> GetEvaluationMethodList([FromForm]SP_EvaluationMethodFilterModel filter) =>
          Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, await _evaluationMethodService.GetEvaluationMethodList(filter)));

        [HttpPost("ConvertToCsv")]
        public async Task<IActionResult> ConvertToCsv(SP_EvaluationMethodFilterModel filter)
        {
            var listOfEvaluationMethod = _mapper.Map<IEnumerable<SP_EvaluationListModel>>(await _evaluationMethodService.GetEvaluationMethodList(filter));
            return new FileContentResult(Encoding.ASCII.GetBytes(Helper.ConvertToCSV(listOfEvaluationMethod.ToList())), "text/csv");
        }
    }
}
