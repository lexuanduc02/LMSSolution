using LMSSolution.ViewModels.Class;
using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Application.Class
{
    public interface IClassService
    {
        Task<ApiResult<List<ClassViewModel>>> GetClassByCourse(int Id);
    }
}
