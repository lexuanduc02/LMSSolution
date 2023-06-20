using AutoMapper;
using LMSSolution.Data.EF;
using LMSSolution.Data.Entities;
using LMSSolution.ViewModels.Class;
using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Course;
using LMSSolution.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

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

                cfg.CreateMap<Data.Entities.Course, CourseDetailViewModel>();

                cfg.CreateMap<Data.Entities.Class, ClassViewModel>();

                cfg.CreateMap<User, UserViewModel>();
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

        public async Task<ApiResult<bool>> Delete(int Id)
        {
            var course = await _context.Courses.FindAsync(Id);

            if(course == null)
            {
                return new ApiErrorResult<bool>("Khóa học không tồn tại!");
            }

            var cl = await _context.Classes.FirstOrDefaultAsync(x => x.CourseId == course.Id);

            if (cl != null)
            {
                return new ApiErrorResult<bool>($"Không thể xóa khóa {course.Name} vì tồn tại lớp trong khóa");
            }

            _context.Courses.Remove(course);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new ApiSuccessResult<bool>();
            }

            return new ApiErrorResult<bool>("Xóa không thành công!");
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

            if (result > 0)
            {
                return new ApiSuccessResult<bool>();
            }

            return new ApiErrorResult<bool>("Cập nhật thất bại!");
        }

        public async Task<ApiResult<PagedResult<CourseViewModel>>> GetAllCoursePaging(GetCoursePagingRequest request)
        {
            var query =  _context.Courses.AsQueryable();

            if(!string.IsNullOrEmpty(request.KeyWord))
            {
                query = query.Where(c => c.Name.Contains(request.KeyWord));
            }

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

        public async Task<ApiResult<CourseViewModel>> GetCourseById(int Id)
        {
            var course = await _context.Courses
                        .FirstOrDefaultAsync(c => c.Id == Id);

            if (course == null)
            {
                return new ApiErrorResult<CourseViewModel>("Khóa không tồn tại!");
            }

            var data = _mapper.Map(course, new CourseViewModel());

            return new ApiSuccessResult<CourseViewModel>(data);
        }

        public async Task<ApiResult<CourseDetailViewModel>> GetCourseDetailById(int Id)
        {
            var course = await _context.Courses
                .Include(c => c.Classes).ThenInclude(cl => cl.Teacher)
                .FirstOrDefaultAsync(c => c.Id == Id);

            if (course == null)
            {
                return new ApiErrorResult<CourseDetailViewModel>("Khóa không tồn tại!");
            }

            var data = _mapper.Map(course, new CourseDetailViewModel());

            return new ApiSuccessResult<CourseDetailViewModel>(data);
        }
    }
}
