using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Subject;
using LMSSolution.ViewModels.System.Teacher;

namespace LMSSolution.ApiIntegration.System.Teacher
{
    public interface ITeacherApiClient
    {
        Task<ApiResult<TeacherDetailViewModel>> GetTeacherDetailById(Guid Id);
        Task<ApiResult<TeacherViewModel>> GetTeacherById(Guid Id);
        Task<ApiResult<bool>> Edit(TeacherEditRequest request);
        Task<ApiResult<bool>> Delete(Guid Id);
        Task<ApiResult<bool>> Create(TeacherCreateRequest request);
        Task<ApiResult<PagedResult<TeacherViewModel>>> GetAllTeacherPaging(GetTeacherPagingRequest request);
    }
}
