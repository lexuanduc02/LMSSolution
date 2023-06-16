using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Application.Course
{
    public interface ICourseService
    {
        Task<ApiResult<bool>> Edit(CourseEditRequest request);
        Task<ApiResult<bool>> Delete(CourseDeleteRequest request);
        Task<ApiResult<bool>> Create(CourseCreateRequest request);
        Task<ApiResult<PagedResult<CourseViewModel>>> GetAllCoursePaging(GetCoursePagingRequest request);
    }
}
