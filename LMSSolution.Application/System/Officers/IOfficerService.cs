using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.System.Offices;

namespace LMSSolution.Application.System.Officers
{
    public interface IOfficerService
    {
        Task<int> Create(OfficerCreateRequest request);

        Task<int> Update(OfficerUpdateRequest request);

        Task<int> Delete(int id);

        Task<List<OfficerViewModel>> GetAll();

        Task<PagedResult<OfficerViewModel>> GetAllPaging(GetOfficerPagingRequest request);
    }
}
