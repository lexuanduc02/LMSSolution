using LMSSolution.Data.EF;
using LMSSolution.Data.Entities;
using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.System.Offices;

namespace LMSSolution.Application.Systems.Officers
{
    public class OfficerService : IOfficerService
    {
        private readonly LMSDbContext _context;
        public OfficerService(LMSDbContext context)
        {
            _context = context;
        }

        public Task<int> Create(OfficerCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(OfficerUpdateRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<List<OfficerViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<OfficerViewModel>> GetAllPaging(GetOfficerPagingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
