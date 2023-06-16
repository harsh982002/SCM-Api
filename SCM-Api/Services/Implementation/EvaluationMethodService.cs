namespace Services.Implementation
{
    using Common.Helpers;
    using Data.Context;
    using Data.Entities;
    using Data.Repository;
    using Microsoft.EntityFrameworkCore;
    using Services.Contract;
    using System.Threading.Tasks;

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
            evaluationMethod.DeletedDate = Helper.GetCurrentUTCDateTime();
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
    }
}
