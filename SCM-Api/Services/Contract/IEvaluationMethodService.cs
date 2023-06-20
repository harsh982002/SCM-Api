namespace Services.Contract
{
    using Data.Entities;
    using Data.StoreProcedureModel;

    public interface IEvaluationMethodService
    {
        /// <summary>
        /// Save EvaluationMethod data.
        /// </summary>
        /// <param name="evaluationMethod">evaluationMethod</param>
        /// <returns>The EvaluationMethodId.</returns>
        Task<int> Save(EvaluationMethod evaluationMethod);

        /// <summary>
        /// Update EvaluationMethod data.
        /// </summary>
        /// <param name="evaluationMethod">evaluationMethod</param>
        /// <returns>The EvaluationMethodId.</returns>
        Task<int> Update(EvaluationMethod evaluationMethod);

        /// <summary>
        /// Get EvulationMethod by Id.
        /// </summary>
        /// <param name="EvaluationMethodId">EvaluationMethodId</param>
        /// <returns>The EvaluationMethod Model</returns>
        Task<EvaluationMethod?> GetById(int EvaluationMethodId);

        /// <summary>
        /// Delete EvaluationMethod data
        /// </summary>
        /// <param name="evaluationMethod">evaluationMethod</param>
        /// <returns>The EvulationMethodId</returns>
        Task<int> Delete(EvaluationMethod evaluationMethod);

        /// <summary>
        /// Get the max value of Thresholdfrom of the EvaluationMethodTable
        /// </summary>
        /// <returns>The Thresholdfrom value</returns>
        Task<decimal> GetMaxThresholdFromValue();

        /// <summary>
        /// Get Evaluation Method list with filter and pagination.
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>The SP_EvaluationListModel</returns>
        Task<IEnumerable<SP_EvaluationMethodListModel>> GetEvaluationMethodList(SP_EvaluationMethodFilterModel filter);
    }
}
