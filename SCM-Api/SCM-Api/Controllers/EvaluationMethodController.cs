namespace SCM_Api.Controllers
{
    using AutoMapper;
    using Common.Constant;
    using Common.Helpers;
    using Data.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contract;
    using Services.Models;
    using System.Net;

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

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int evaluationMethodId)
        {
            var evaluationMethod = await _evaluationMethodService.GetById(evaluationMethodId);
            if (evaluationMethod == null)
            {
                return this.NotFound(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"EvaluationMethod data not found." }, evaluationMethodId));
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

            return BadRequest(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { MessageConstant.RequestUnSuccessful, "ThresholdFrom must be less than ThresholdTo" }));
        }

        /// <summary>
        /// Update the EvaluationMethod data by Id.
        /// </summary>
        /// <param name="evaluationMethodId"></param>
        /// <param name="model"></param>
        /// <returns>The Api Response</returns>
        [HttpPost("UpdateEvaluationMethod")]
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
                    return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, evaluationMethodId));
                }
                else
                {
                    return this.BadRequest(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { MessageConstant.RequestUnSuccessful, "ThresholdFrom must be less than ThresholdTo" }));
                }
            }
            else
            {
                return this.Ok(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"Evuluation Method data not found." }, evaluationMethodId));
            }
        }

        /// <summary>zz
        /// Delete EvaluationMethod data by Id.
        /// </summary>
        /// <param name="evaluationMethodId"></param>
        /// <returns></returns>
        [HttpPost("DeleteEvaluationMethod")]
        public async Task<IActionResult> DeleteEvaluationMethod(int evaluationMethodId)
        {
            EvaluationMethod? evaluationMethod = await _evaluationMethodService.GetById(evaluationMethodId);
            if (evaluationMethod != null && evaluationMethod.DeletedDate == null)
            {
                return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, await _evaluationMethodService.Delete(evaluationMethod)));
            }
            else
            {
                return this.Ok(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"Evuluation Method data not found." }, evaluationMethodId));
            }
        }
    }
}
