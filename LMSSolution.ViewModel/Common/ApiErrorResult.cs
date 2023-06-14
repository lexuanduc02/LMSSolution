using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.ViewModels.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[] ValidationErrors { get; set; }

        public ApiErrorResult(string massage)
        {
            IsSuccess = false;
            Message = massage;
        }

        public ApiErrorResult(string[] validationErrors)
        {
            IsSuccess = false;
            ValidationErrors = validationErrors;
        }
    }
}
