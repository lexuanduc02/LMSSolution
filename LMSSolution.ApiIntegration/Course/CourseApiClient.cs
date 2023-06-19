using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.Course;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Bogus.Bson;
using Azure.Core;

namespace LMSSolution.ApiIntegration.Course
{
    public class CourseApiClient : ICourseApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public CourseApiClient(IHttpContextAccessor httpContextAccessor, 
            IHttpClientFactory httpClientFactory, 
            IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<ApiResult<bool>> Create(CourseCreateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddressUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("LoginToken"));

            var response = await client.PostAsync($"/api/courses/create", httpContent);

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return new ApiSuccessResult<bool>();
            };

            return new ApiErrorResult<bool>(result);
        }

        public async Task<ApiResult<bool>> Delete(CourseDeleteRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddressUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("LoginToken"));

            var response = await client.DeleteAsync($"/api/courses/{request.Id}");

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return new ApiSuccessResult<bool>();
            };

            return new ApiErrorResult<bool>(result);
        }

        public async Task<ApiResult<CourseViewModel>> GetCourse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddressUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("LoginToken"));

            var response = await client.GetAsync($"api/courses/{id}");
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject <ApiSuccessResult<CourseViewModel>>(result);
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<CourseViewModel>>(result);
        }

        public async Task<ApiResult<CourseDetailViewModel>> GetCourseDetailById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddressUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("LoginToken"));

            var response = await client.GetAsync($"api/courses/detail/{id}");
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<CourseDetailViewModel>>(result);
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<CourseDetailViewModel>>(result);
        }

        public async Task<ApiResult<PagedResult<CourseViewModel>>> GetCoursesPaging(GetCoursePagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddressUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("LoginToken"));

            var response = await client.GetAsync($"api/courses/Paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyWord={request.KeyWord}");

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return new ApiSuccessResult<PagedResult<CourseViewModel>>(JsonConvert.DeserializeObject<PagedResult<CourseViewModel>>(result));
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<PagedResult<CourseViewModel>>>(result);
        }
    }
}
