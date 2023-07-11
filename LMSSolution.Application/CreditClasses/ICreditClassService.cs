using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.CreditClass;

namespace LMSSolution.Application.CreditClasses
{
    public interface ICreditClassService
    {
        Task<ApiResult<bool>> Edit(CreditClassEditRequest request);
        Task<ApiResult<bool>> Delete(int Id);
        Task<ApiResult<bool>> Create(CreditClassCreateRequest request);
        Task<ApiResult<bool>> TeachingAssign(TeachingAssignRequest request);
        Task<ApiResult<CreditClassDetailViewModel>> GetCreditClassDetailById(int Id);
        Task<ApiResult<CreditClassViewModel>> GetCreditClassById(int Id);
        Task<ApiResult<PagedResult<CreditClassViewModel>>> GetAllCreditClassPaging(GetCreditClassPagingRequest request);
        Task<ApiResult<List<CreditClassViewModel>>> GetAllCreditClass();
    }
}
