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
                cfg.CreateMap<CreditClass, CreditClassViewModel>();
                cfg.CreateMap<Subject, SubjectDto>();
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

        public async Task<ApiResult<PagedResult<CreditClassViewModel>>> GetAllCreditClassPaging(GetCreditClassPagingRequest request)
        {
            var query = _context.CreditClasses.Include(x => x.Subject).AsQueryable();

            //filter by KeyWord
            if (!string.IsNullOrEmpty(request.KeyWord))
            {
                query = query.Where(x => x.Name.Contains(request.KeyWord) || x.Name.Contains(request.KeyWord));
            }

            if(request.StartDate != null)
            {
                query = query.Where(x => x.StartDate >= request.StartDate);
            }

            if (request.EndDate != null)
            {
                query = query.Where(x => x.EndDate <= request.EndDate);
            }

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                                .Take(request.PageSize)
                                .OrderByDescending(c => c.Name)
                                .Select(c => _mapper.Map(c, new CreditClassViewModel()))
                                .ToListAsync();

            var pagedResult = new PagedResult<CreditClassViewModel>()
            {
                TotalRecords = query.Count(),
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };

            return new ApiSuccessResult<PagedResult<CreditClassViewModel>>(pagedResult);
        }

        public Task<ApiResult<CreditClassViewModel>> GetCreditClassById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<CreditClassDetailViewModel>> GetCreditClassDetailById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<bool>> TeachingAssign(TeachingAssignRequest request)
        {
            var creditClass = await _context.CreditClasses.FindAsync(request.CreditClassId);

            if(creditClass == null)
            {
                return new ApiErrorResult<bool>("Lớp tín chỉ không tồn tại");
            }

            var lessons = new List<Lesson>();

            for (var date = creditClass.StartDate; date <= creditClass.EndDate; date = date.AddDays(7))
            {
                lessons.Add(new Lesson()
                {
                    Date = date,
                    Status = Data.Enum.LessonStatusEnum.Study,
                    StadyShiffId = request.StadyShiffId,
                    CreditClassId = request.CreditClassId,
                    TeacherId = request.TeacherId,
                });
            }

            try
            {
                await _context.Lessons.AddRangeAsync(lessons);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                return new ApiErrorResult<bool>("Phân công thất bại");
            }

            return new ApiSuccessResult<bool>();
        }
    }
}
