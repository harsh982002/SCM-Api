namespace Services.Contract
{
    using Data.Entities;

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
    }
}
