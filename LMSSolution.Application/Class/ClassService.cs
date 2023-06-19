using AutoMapper;
using LMSSolution.Data.EF;
using LMSSolution.Data.Entities;
using LMSSolution.ViewModels.Class;
using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Course;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Application.Class
{
    public class ClassService : IClassService
    {
        private readonly LMSDbContext _context;
        private readonly IMapper _mapper;

        public ClassService(LMSDbContext context)
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

        public async Task<ApiResult<List<ClassViewModel>>> GetClassByCourse(int Id)
        {
            var query = from c in _context.Classes
                          join t in _context.Users on c.TeacherId equals t.Id into ct
                          from t in ct.DefaultIfEmpty()
                          where c.CourseId == Id
                          select new {c, t};

            if(query == null)
            {
                return new ApiErrorResult<List<ClassViewModel>>("Not Found");
            }

            var data = await query.Select(x => new ClassViewModel()
            {
                Id = x.c.Id,
                Name = x.c.Name,
            }).ToListAsync();

            return new ApiSuccessResult<List<ClassViewModel>>(data);
        }
    }
}
