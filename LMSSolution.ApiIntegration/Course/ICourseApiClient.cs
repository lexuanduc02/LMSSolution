using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ApiIntegration.Course
{
    public interface ICourseApiClient
    {
        Task<ApiResult<bool>> Create(CourseCreateRequest request);
        Task<ApiResult<PagedResult<CourseViewModel>>> GetCoursesPaging(GetCoursePagingRequest request);
    }
}
