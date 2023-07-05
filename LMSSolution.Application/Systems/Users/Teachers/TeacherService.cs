using AutoMapper;
using LMSSolution.Data.EF;
using LMSSolution.Data.Entities;
using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.System.Teacher;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LMSSolution.Application.Systems.Users.Teachers
{
    public class TeacherService : ITeacherService
    {
        private readonly LMSDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public TeacherService(LMSDbContext context, 
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TeacherCreateRequest, User>();
                cfg.CreateMap<User, TeacherViewModel>();
                cfg.CreateMap<User, TeacherDetailViewModel>();
                cfg.CreateMap<Class, ClassDTO>();
            });

            _mapper = config.CreateMapper();
        }

        public async Task<ApiResult<bool>> Create(TeacherCreateRequest request)
        {
            var teacher = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName || x.Email == request.Email);

            if (teacher != null) 
            {
                return new ApiErrorResult<bool>("Người dùng đã tồn tại");
            }

            var newTeacher = new User();
            _mapper.Map(request, newTeacher);

            if (request.SubjectIds != null)
            {
                var subjects = await _context.Subjects.Select(x => x.Id).ToListAsync();
                var subjectSli = request.SubjectIds;
                subjectSli.RemoveAll(s => !subjects.Contains(s));

                newTeacher.TeacherSubjects = subjectSli.Select(x => new TeacherSubject
                {
                    SubjectId = x,
                }).ToList();
            }

            var result = await _userManager.CreateAsync(newTeacher, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newTeacher, "Teacher");

                if (request.ClassIds != null)
                {
                    var classes = await _context.Classes.Select(x => x.Id).ToListAsync();
                    var classSli = request.ClassIds;
                    classSli.RemoveAll(c => !classes.Contains(c));

                    foreach (var item in classSli)
                    {
                        await ClassAssign(item, newTeacher.Id);
                    }
                }

                return new ApiSuccessResult<bool>();
            }
            else
                return new ApiErrorResult<bool>("Thêm mới không thành công!");
        }

        public async Task<ApiResult<bool>> Delete(Guid Id)
        {
            var teacher = await _userManager.FindByIdAsync(Id.ToString());

            if (teacher == null)
            {
                return new ApiErrorResult<bool>("Môn học không tồn tạo");
            }

            try
            {
                await _userManager.DeleteAsync(teacher);
            }
            catch (DbUpdateException)
            {
                return new ApiErrorResult<bool>("Xóa không thành công");
            }

            return new ApiSuccessResult<bool>();
        }

        public Task<ApiResult<bool>> Edit(TeacherEditRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<List<TeacherViewModel>>> GetAllTeacher()
        {
            var query = await _userManager.GetUsersInRoleAsync("Teacher");

            var data = query.Select(x => _mapper.Map(x, new TeacherViewModel()))
                            .ToList();

            return new ApiSuccessResult<List<TeacherViewModel>>(data);
        }

        public async Task<ApiResult<PagedResult<TeacherViewModel>>> GetAllTeacherPaging(GetTeacherPagingRequest request)
        {
            var query = (await _userManager.GetUsersInRoleAsync("Teacher")).AsQueryable();

            //filter by KeyWord
            if (!string.IsNullOrEmpty(request.KeyWord))
            {
                query = query.Where(m => m.FirstName.Contains(request.KeyWord) || m.LastName.Contains(request.KeyWord));
            }

            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                                .Take(request.PageSize)
                                .OrderByDescending(c => c.Dob)
                                .Select(c => _mapper.Map(c, new TeacherViewModel())).ToList();

            var pagedResult = new PagedResult<TeacherViewModel>()
            {
                TotalRecords = query.Count(),
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };

            return new ApiSuccessResult<PagedResult<TeacherViewModel>>(pagedResult);
        }

        public async Task<ApiResult<TeacherViewModel>> GetTeacherById(Guid Id)
        {
            var teacher = await _context.Users
                        .FirstOrDefaultAsync(s => s.Id == Id);

            if (teacher == null)
            {
                return new ApiErrorResult<TeacherViewModel>("Khóa không tồn tại!");
            }

            var data = _mapper.Map(teacher, new TeacherViewModel());

            return new ApiSuccessResult<TeacherViewModel>(data);
        }

        public async Task<ApiResult<TeacherDetailViewModel>> GetTeacherDetailById(Guid Id)
        {
            var teacher = await _context.Users
                .Include(s => s.Classes)
                .FirstOrDefaultAsync(s => s.Id == Id);

            if (teacher == null)
            {
                return new ApiErrorResult<TeacherDetailViewModel>("Khóa không tồn tại!");
            }

            var data = _mapper.Map(teacher, new TeacherDetailViewModel());

            return new ApiSuccessResult<TeacherDetailViewModel>(data);
        }

        private async Task<bool> ClassAssign(int classId, Guid teacherId)
        {
            try
            {
                var c = await _context.Classes.FindAsync(classId);

                c.TeacherId = teacherId;

                _context.Classes.Update(c);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }
    }
}
