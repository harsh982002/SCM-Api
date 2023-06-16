namespace Services.Contract
{
    using Services.Models;

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
