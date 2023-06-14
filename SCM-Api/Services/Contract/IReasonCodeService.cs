using Services.Models;

namespace Services.Contract
{
    public interface IReasonCodeService
    {
        /// <summary>
        /// Get ReasonCode list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ReasonCodeModel.</returns>
        Task<IEnumerable<ReasonCodeModel?>> GetReasonCodeList();
    }
}
