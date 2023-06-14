using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ApiIntegration
{
    public class BaseApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public BaseApiClient(IHttpContextAccessor httpContextAccessor, 
            IHttpClientFactory httpClientFactory, 
            IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        protected GetAsync(string url)
        {

        }
    }
}
