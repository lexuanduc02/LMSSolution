using AutoMapper;
using Azure.Core;
using LMSSolution.Data.EF;
using LMSSolution.Data.Entities;
using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Course;
using LMSSolution.ViewModels.Major;
using Microsoft.EntityFrameworkCore;

namespace LMSSolution.Application.Majors
{
    public class MajorService : IMajorService
    {
        private readonly LMSDbContext _context;
        private readonly IMapper _mapper;

        public MajorService(LMSDbContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MajorCreateRequest, Major>();
                cfg.CreateMap<Major, MajorViewModel>();
                cfg.CreateMap<Major, MajorDetailViewModel>();
                cfg.CreateMap<MajorEditRequest, Major>();
                cfg.CreateMap<Class, ClassViewModel>();
                cfg.CreateMap<User, TeacherViewModel>();
                cfg.CreateMap<SubjectMajor, SubjectMajorViewModel>();
                cfg.CreateMap<Subject, SubjectViewModel>();
                cfg.CreateMap<Course, ViewModels.Major.CourseViewModel>();
            });

            _mapper = config.CreateMapper();
        }

        public async Task<ApiResult<bool>> Create(MajorCreateRequest request)
        {
            var major = await _context.Majors.FirstOrDefaultAsync(x => x.Name == request.Name);

            if (major != null)
            {
                return new ApiErrorResult<bool>("Chuyên ngành đã tồn tạo");
            }

            var dto = _mapper.Map(request, new Major());

            _context.Majors.Add(dto);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new ApiSuccessResult<bool>();
            }

            return new ApiErrorResult<bool>("Thêm mới thất bại");
        }

        public async Task<ApiResult<bool>> Delete(int Id)
        {
            var major = await _context.Majors.FindAsync(Id);

            if (major == null)
            {
                return new ApiErrorResult<bool>("Chuyên ngành không tồn tại!");
            }

            try
            {
                _context.Majors.Remove(major);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return new ApiErrorResult<bool>("Xóa không thành công");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Edit(MajorEditRequest request)
        {
            var major = await _context.Majors.FindAsync(request.Id);

            if (major == null)
            {
                return new ApiErrorResult<bool>("Chuyên ngành không tồn tại!");
            }

            _mapper.Map(request, major);

            _context.Majors.Update(major);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new ApiSuccessResult<bool>();
            }

            return new ApiErrorResult<bool>("Cập nhật thất bại!");
        }

        public async Task<ApiResult<PagedResult<MajorViewModel>>> GetAllMajorPaging(GetMajorPagingRequest request)
        {
            var query = _context.Majors.AsQueryable();

            //filter by KeyWord
            if(!string.IsNullOrEmpty(request.KeyWord))
            {
                query = query.Where(m => m.Description.Contains(request.KeyWord) || m.Name.Contains(request.KeyWord));
            }

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                                .Take(request.PageSize)
                                .OrderByDescending(c => c.Name)
                                .Select(c => _mapper.Map(c, new MajorViewModel()))
                                .ToListAsync();

            var pagedResult = new PagedResult<MajorViewModel>()
            {
                TotalRecords = query.Count(),
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };

            return new ApiSuccessResult<PagedResult<MajorViewModel>>(pagedResult);
        }

        public async Task<ApiResult<MajorViewModel>> GetMajorById(int Id)
        {
            var major = await _context.Majors.FindAsync(Id);

            if(major == null)
            {
                return new ApiErrorResult<MajorViewModel>("Chuyên ngành không tồn tại!");
            }

            var data = _mapper.Map(major, new MajorViewModel());

            return new ApiSuccessResult<MajorViewModel>(data);

        }

        public async Task<ApiResult<MajorDetailViewModel>> GetMajorDetailById(int Id)
        {
            var major = await _context.Majors
                .Include(m => m.SubjectMajors).ThenInclude(sm => sm.Subject)
                .Include(m => m.Classes).ThenInclude(cl => cl.Teacher)
                .Include(m => m.Classes).ThenInclude(cl => cl.Course)
                .FirstOrDefaultAsync(m => m.Id == Id);

            if (major == null)
            {
                return new ApiErrorResult<MajorDetailViewModel>("Khóa không tồn tại!");
            }

            var data = _mapper.Map(major, new MajorDetailViewModel());

            return new ApiSuccessResult<MajorDetailViewModel>(data);
        }
    }
}
