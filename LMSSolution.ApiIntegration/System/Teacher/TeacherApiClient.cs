using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Course;
using LMSSolution.ViewModels.System.Teacher;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace LMSSolution.ApiIntegration.System.Teacher
{
    public class TeacherApiClient : ITeacherApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public TeacherApiClient(IHttpContextAccessor httpContextAccessor, 
            IHttpClientFactory httpClientFactory, 
            IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public Task<ApiResult<bool>> Create(TeacherCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> Edit(TeacherEditRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<PagedResult<TeacherViewModel>>> GetAllTeacherPaging(GetTeacherPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<TeacherViewModel>> GetTeacherById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<TeacherDetailViewModel>> GetTeacherDetailById(Guid Id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddressUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("LoginToken"));

            var response = await client.GetAsync($"api/users/teacher/detail/{Id}");
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<TeacherDetailViewModel>>(result);
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<TeacherDetailViewModel>>(result);
        }
    }
}
