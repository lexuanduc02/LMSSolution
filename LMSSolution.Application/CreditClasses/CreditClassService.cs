using AutoMapper;
using LMSSolution.Data.EF;
using LMSSolution.Data.Entities;
using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.CreditClass;
using Microsoft.EntityFrameworkCore;

namespace LMSSolution.Application.CreditClasses
{
    public class CreditClassService : ICreditClassService
    {
        private readonly LMSDbContext _context;
        private readonly IMapper _mapper;

        public CreditClassService(LMSDbContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreditClassCreateRequest, CreditClass>();
            });

            _mapper = config.CreateMapper();
        }

        public async Task<ApiResult<bool>> Create(CreditClassCreateRequest request)
        {
            var checkSubject = await _context.Subjects.FindAsync(request.SubjectId);
            if(checkSubject == null)
            {
                return new ApiErrorResult<bool>("Môn học không tồn tại.");
            }

            var checkExist = await _context.CreditClasses.FirstOrDefaultAsync(x => x.Name == request.Name);
            if(checkExist != null)
            {
                return new ApiErrorResult<bool>("Lớp tín chỉ đã tồn tại.");
            }

            var numberOfLessions = checkSubject.NumberOfLesson;

            var numberOfSessions = (numberOfLessions / 4) + 1;

            request.EndDate = request.StartDate.Value.AddDays((numberOfSessions - 1) * 7);

            var newCreditClass = new CreditClass();

            _mapper.Map(request, newCreditClass);

            try
            {
                _context.CreditClasses.Add(newCreditClass);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return new ApiErrorResult<bool>("Thêm mới thất bại");
            }

            return new ApiSuccessResult<bool>();
        }

        public Task<ApiResult<bool>> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> Edit(CreditClassEditRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<List<CreditClassViewModel>>> GetAllCreditClass()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<PagedResult<CreditClassViewModel>>> GetAllCreditClassPaging(GetCreditClassPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<CreditClassViewModel>> GetCreditClassById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<CreditClassDetailViewModel>> GetCreditClassDetailById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
