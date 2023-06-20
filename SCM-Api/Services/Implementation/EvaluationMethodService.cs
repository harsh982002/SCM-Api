namespace Services.Implementation
{
    using Common.Helpers;
    using Data.Context;
    using Data.Entities;
    using Data.Repository;
    using Data.StoreProcedureModel;
    using Microsoft.EntityFrameworkCore;
    using Services.Contract;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static Common.Helpers.Enum;

    public class EvaluationMethodService : RepositoryBase<EvaluationMethod>, IEvaluationMethodService
    {
        public EvaluationMethodService(Context context) : base(context)
        {

        }

        /// <summary>
        /// Delete EvaluationMethod data
        /// </summary>
        /// <param name="evaluationMethod">evaluationMethod</param>
        /// <returns>The EvulationMethodId</returns>
        public async Task<int> Delete(EvaluationMethod evaluationMethod)
        {
            evaluationMethod.StatusId = (byte)GeneralStatuses.Delete;
            this.UpdateEntity(evaluationMethod);
            await this.SaveAsync();
            return evaluationMethod.EvaluationMethodId;
        }

        /// <summary>
        /// Get EvulationMethod by Id.
        /// </summary>
        /// <param name="EvaluationMethodId">EvaluationMethodId</param>
        /// <returns>The EvaluationMethod Model</returns>
        public async Task<EvaluationMethod?> GetById(int EvaluationMethodId) =>
            await this.Find(x => x.EvaluationMethodId == EvaluationMethodId).FirstOrDefaultAsync();

        /// <summary>
        /// Save EvaluationMethod data.
        /// </summary>
        /// <param name="evaluationMethod">evaluationMethod</param>
        /// <returns>The EvaluationMethodId.</returns>
        public async Task<int> Save(EvaluationMethod evaluationMethod)
        {
            evaluationMethod.CreatedDate = Helper.GetCurrentUTCDateTime();
            this.CreateEntity(evaluationMethod);
            await this.SaveAsync();
            return evaluationMethod.EvaluationMethodId;
        }

        /// <summary>
        /// Update EvaluationMethod data.
        /// </summary>
        /// <param name="evaluationMethod">evaluationMethod</param>
        /// <returns>The EvaluationMethodId.</returns>
        public async Task<int> Update(EvaluationMethod evaluationMethod)
        {
            evaluationMethod.UpdatedDate = Helper.GetCurrentUTCDateTime();
            this.UpdateEntity(evaluationMethod);
            await this.SaveAsync();
            return evaluationMethod.EvaluationMethodId;
        }

        /// <summary>
        /// Get the max value of Thresholdfrom of the EvaluationMethodTable
        /// </summary>
        /// <returns>The Thresholdfrom value</returns>
        public async Task<decimal> GetMaxThresholdFromValue()
        {
            decimal thresholdFrom = 0;
            List<EvaluationMethod> evaluationMethods = await this.Find(x => x.StatusId != (byte)GeneralStatuses.Delete).ToListAsync();
            if (evaluationMethods != null && evaluationMethods.Count > 0)
            {
                decimal maxThresholdTo = evaluationMethods.Max(x => x.ThresholdTo);
                thresholdFrom = maxThresholdTo + (decimal)0.01;
            }
            else
            {
                thresholdFrom = (decimal)00.01;
            }

            return thresholdFrom;
        }

        /// <summary>
        /// Get Evaluation Method list with filter and pagination.
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>The SP_EvaluationListModel</returns>
        public async Task<IEnumerable<SP_EvaluationMethodListModel>> GetEvaluationMethodList(SP_EvaluationMethodFilterModel filter) =>
            await this.ExecuteStoredProcedureListAsync<SP_EvaluationMethodListModel>($"EXEC [dbo].[GetEvaluationMethodList] @SortColumn = {filter.SortColumn},@SortOrder = {filter.SortOrder},@PageNumber = {filter.PageNumber},@PageSize = {filter.PageSize},@Status = {filter.Status}");

    }
}
