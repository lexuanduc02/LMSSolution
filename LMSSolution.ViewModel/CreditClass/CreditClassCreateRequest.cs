using LMSSolution.Utilities.Enums;

namespace LMSSolution.ViewModels.CreditClass
{
    public class CreditClassCreateRequest
    {
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public CreditClassStatusEnum? Status { get; set; }
        public int? SubjectId { get; set; }
    }
}
