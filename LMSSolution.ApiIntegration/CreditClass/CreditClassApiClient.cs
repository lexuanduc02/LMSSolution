using LMSSolution.ViewModels.Common;
using LMSSolution.ViewModels.CreditClass;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace LMSSolution.ApiIntegration.CreditClass
{
    public class CreditClassApiClient : ICreditClassApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public CreditClassApiClient(IHttpContextAccessor httpContextAccessor, 
            IHttpClientFactory httpClientFactory, 
            IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public Task<ApiResult<CreditClassViewModel>> Create(CreditClassCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> Edit(CreditClassEditRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<List<CreditClassViewModel>>> GetAllCreditClass()
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<PagedResult<CreditClassViewModel>>> GetAllCreditClassPaging(GetCreditClassPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddressUri"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _httpContextAccessor.HttpContext.Session.GetString("LoginToken"));

            var response = await client.GetAsync($"api/creditclasses/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyWord={request.KeyWord}&startDate={request.StartDate}&endDate={request.EndDate}");

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return new ApiSuccessResult<PagedResult<CreditClassViewModel>>(JsonConvert.DeserializeObject<PagedResult<CreditClassViewModel>>(result));
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<PagedResult<CreditClassViewModel>>>(result);
        }

        public Task<ApiResult<CreditClassViewModel>> GetCreditClassById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<CreditClassDetailViewModel>> GetCreditClassDetailById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> TeachingAssign(TeachingAssignRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
