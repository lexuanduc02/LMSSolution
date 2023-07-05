using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ApiIntegration.Subject
{
    public interface ISubjectApiClient
    {
        Task<ApiResult<SubjectDetailViewModel>> GetSubjectDetailById(int Id);
        Task<ApiResult<SubjectViewModel>> GetSubjectById(int Id);
        Task<ApiResult<bool>> Edit(SubjectEditRequest request);
        Task<ApiResult<bool>> Delete(int Id);
        Task<ApiResult<bool>> Create(SubjectCreateRequest request);
        Task<ApiResult<PagedResult<SubjectViewModel>>> GetAllSubjectPaging(GetSubjectPagingRequest request);
    }
}
