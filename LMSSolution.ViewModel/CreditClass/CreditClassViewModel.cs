using LMSSolution.Utilities.Enums;

namespace LMSSolution.ViewModels.CreditClass
{
    public class CreditClassViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CreditClassStatusEnum Status { get; set; }
        public SubjectDto Subject { get; set; }
    }

    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
