using AutoMapper;
using LMSSolution.Data.EF;
using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Course;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace LMSSolution.Application.Course
{
    public class CourseService : ICourseService
    {
        private readonly LMSDbContext _context;
        private readonly IMapper _mapper;

        public CourseService(LMSDbContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourseCreateRequest, Data.Entities.Course>();
                cfg.CreateMap<CourseEditRequest, Data.Entities.Course>();
                cfg.CreateMap<Data.Entities.Course, CourseViewModel>();
            });

            _mapper = config.CreateMapper();
        }

        public async Task<ApiResult<bool>> Create(CourseCreateRequest request)
        {
            var course = new Data.Entities.Course();

            _mapper.Map(request, course);

             _context.Courses.Add(course);
            var result = await _context.SaveChangesAsync();

            if(result == 1)
            {
                return new ApiSuccessResult<bool>();
            }

            return new ApiErrorResult<bool>("Thêm mới khóa học thất bại!");
        }

        public async Task<ApiResult<bool>> Delete(CourseDeleteRequest request)
        {
            var course = await _context.Courses.FindAsync(request.Id);

            if(course == null)
            {
                return new ApiErrorResult<bool>("Khóa học không tồn tại!");
            }

            _context.Courses.Remove(course);

            var result = await _context.SaveChangesAsync();

            if(result != 1)
            {
                return new ApiErrorResult<bool>("Xóa không thành công!");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Edit(CourseEditRequest request)
        {
            var course = await _context.Courses.FindAsync(request.Id);

            if(course == null)
            {
                return new ApiErrorResult<bool>("Khóa học không tồn tại!");
            }

            _mapper.Map(request, course);

            _context.Courses.Update(course);

            var result = await _context.SaveChangesAsync();

            if (result != 1)
            {
                return new ApiErrorResult<bool>("Cập nhật thất bại!");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<CourseViewModel>>> GetAllCoursePaging(GetCoursePagingRequest request)
        {
            var query =  _context.Courses;

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                                .Take(request.PageSize)
                                .OrderByDescending(c => c.StartDate)
                                .Select(c => _mapper.Map(c, new CourseViewModel()))
                                .ToListAsync();

            var pagedResult = new PagedResult<CourseViewModel>()
            {
                TotalRecords = query.Count(),
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };

            return new ApiSuccessResult<PagedResult<CourseViewModel>>(pagedResult);
        }
    }
}
