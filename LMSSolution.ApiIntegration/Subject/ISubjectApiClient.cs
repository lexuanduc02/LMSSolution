using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Subject;

namespace LMSSolution.ApiIntegration.Subject
{
    public interface ISubjectApiClient
    {
        Task<ApiResult<SubjectDetailViewModel>> GetSubjectDetailById(int Id);
        Task<ApiResult<SubjectViewModel>> GetSubjectById(int Id);
        Task<ApiResult<bool>> Edit(SubjectEditRequest request);
        Task<ApiResult<bool>> Delete(int Id);
        Task<ApiResult<bool>> Create(SubjectCreateRequest request);
        Task<ApiResult<PagedResult<SubjectViewModel>>> GetAllSubjectPaging(GetSubjectPagingRequest request);
        Task<List<SubjectViewModel>> GetAllSubject();
    }
}
