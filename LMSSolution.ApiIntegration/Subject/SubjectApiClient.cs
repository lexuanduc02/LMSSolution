using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Subject;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace LMSSolution.ApiIntegration.Subject
{
    public class SubjectApiClient : ISubjectApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SubjectApiClient(IConfiguration configuration, 
            IHttpClientFactory httpClientFactory, 
            IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<bool>> Create(SubjectCreateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddressUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("LoginToken"));

            var response = await client.PostAsync($"/api/subjects/create", httpContent);

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return new ApiSuccessResult<bool>();
            };

            return new ApiErrorResult<bool>(result);
        }

        public Task<ApiResult<bool>> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> Edit(SubjectEditRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SubjectViewModel>> GetAllSubject()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddressUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("LoginToken"));

            var response = await client.GetAsync($"api/subjects/all");
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<SubjectViewModel>>(result);
            }

            return JsonConvert.DeserializeObject<List<SubjectViewModel>>(result);
        }

        public async Task<ApiResult<PagedResult<SubjectViewModel>>> GetAllSubjectPaging(GetSubjectPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddressUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("LoginToken"));

            var response = await client.GetAsync($"api/subjects/Paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyWord={request.KeyWord}");

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<PagedResult<SubjectViewModel>>(result);
                return new ApiSuccessResult<PagedResult<SubjectViewModel>>(data);
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<PagedResult<SubjectViewModel>>>(result);
        }

        public Task<ApiResult<SubjectViewModel>> GetSubjectById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<SubjectDetailViewModel>> GetSubjectDetailById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
