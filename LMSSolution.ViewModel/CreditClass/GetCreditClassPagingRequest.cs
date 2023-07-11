using LMSSolution.ViewModels.Common;

namespace LMSSolution.ViewModels.CreditClass
{
    public class GetCreditClassPagingRequest : PagingRequestBase
    {
        public string? KeyWord { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
