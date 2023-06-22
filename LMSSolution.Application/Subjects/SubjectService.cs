using AutoMapper;
using LMSSolution.Data.EF;
using LMSSolution.Data.Entities;
using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Subject;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace LMSSolution.Application.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly LMSDbContext _context;
        private readonly IMapper _mapper;

        public SubjectService(LMSDbContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SubjectCreateRequest, Subject>();
                cfg.CreateMap<Subject, SubjectViewModel>();
                cfg.CreateMap<Subject, SubjectDetailViewModel>();
                cfg.CreateMap<Major, MajorDto>();
                cfg.CreateMap<User, TeacherDto>();
                cfg.CreateMap<SubjectEditRequest, Subject>();

                cfg.CreateMap<SubjectMajor, SubjectMajorDto>()
                    .ForMember(dest => dest.MajorInfor, opt => opt.MapFrom(src => src.Major));

                cfg.CreateMap<TeacherSubject, TeacherSubjectDto>()
                    .ForMember(dest => dest.TeacherInfor, opt => opt.MapFrom(src => src.Teacher));
            });

            _mapper = config.CreateMapper();
        }

        public async Task<ApiResult<bool>> Create(SubjectCreateRequest request)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Name == request.Name);

            if (subject != null)
            {
                return new ApiErrorResult<bool>("Chuyên ngành đã tồn tạo");
            }

            var major = await _context.Majors.Select(x => x.Id).ToListAsync();

            var majorSli = request.MajorId;

            majorSli.RemoveAll(m => !major.Contains(m));

            var newSubject = new Subject()
            {
                Name = request.Name,
                NumberOfLesson = (int)request.NumberOfLesson,
                SubjectMajors = majorSli.Select(x => new SubjectMajor
                {
                    MajorId = x,
                }).ToList(),
            };

            //newSubject.SubjectMajors = new List<SubjectMajor>();

            //foreach (var item in request.MajorId)
            //{
            //    newSubject.SubjectMajors.Add(new SubjectMajor
            //    {
            //        MajorId = item,
            //    });
            //}

            try
            {
                _context.Subjects.Add(newSubject);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return new ApiErrorResult<bool>("Thêm mới thất bại");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int Id)
        {
            var subject = await _context.Subjects.FindAsync(Id);

            if (subject == null)
            {
                return new ApiErrorResult<bool>("Môn học không tồn tạo");
            }

            try
            {
               _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return new ApiErrorResult<bool>("Xóa không thành công");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Edit(SubjectEditRequest request)
        {
            var subject = await _context.Subjects.FindAsync(request.Id);

            if(subject == null)
            {
                return new ApiErrorResult<bool>("Không tìm thấy môn học!");
            }

            _mapper.Map(request, subject);

            try
            {
                _context.Subjects.Update(subject);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return new ApiErrorResult<bool>("Xóa không thành công!");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<SubjectViewModel>>> GetAllSubjectPaging(GetSubjectPagingRequest request)
        {
            var query = _context.Subjects.AsQueryable();

            //filter by KeyWord
            if (!string.IsNullOrEmpty(request.KeyWord))
            {
                query = query.Where(m => m.Name.Contains(request.KeyWord) || m.Name.Contains(request.KeyWord));
            }

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                                .Take(request.PageSize)
                                .OrderByDescending(c => c.Name)
                                .Select(c => _mapper.Map(c, new SubjectViewModel()))
                                .ToListAsync();

            var pagedResult = new PagedResult<SubjectViewModel>()
            {
                TotalRecords = query.Count(),
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };

            return new ApiSuccessResult<PagedResult<SubjectViewModel>>(pagedResult);
        }

        public Task<ApiResult<SubjectViewModel>> GetSubjectById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<SubjectDetailViewModel>> GetSubjectDetailById(int Id)
        {
            var subject = await _context.Subjects
                .Include(s => s.TeacherSubjects).ThenInclude(ts => ts.Teacher)
                .Include(s => s.SubjectMajors).ThenInclude(sm => sm.Major)
                .FirstOrDefaultAsync(s => s.Id == Id);

            if (subject == null)
            {
                return new ApiErrorResult<SubjectDetailViewModel>("Khóa không tồn tại!");
            }

            var data = _mapper.Map(subject, new SubjectDetailViewModel());

            return new ApiSuccessResult<SubjectDetailViewModel>(data);
        }
    }
}
