using LMSSolution.Data.Enum;

namespace LMSSolution.ViewModels.CreditClass
{
    public class TeachingAssignRequest
    {
        public int CreditClassId { get; set; }
        public int StadyShiffId { get; set; }
        public Guid TeacherId { get; set; }
    }
}
