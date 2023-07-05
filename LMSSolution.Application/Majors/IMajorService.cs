using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Major;

namespace LMSSolution.Application.Majors
{
    public interface IMajorService
    {
        Task<ApiResult<MajorDetailViewModel>> GetMajorDetailById(int Id);
        Task<ApiResult<MajorViewModel>> GetMajorById(int Id);
        Task<ApiResult<bool>> Edit(MajorEditRequest request);
        Task<ApiResult<bool>> Delete(int Id);
        Task<ApiResult<bool>> Create(MajorCreateRequest request);
        Task<ApiResult<PagedResult<MajorViewModel>>> GetAllMajorPaging(GetMajorPagingRequest request);
        Task<List<MajorViewModel>> GetAllMajor();
    }
}
