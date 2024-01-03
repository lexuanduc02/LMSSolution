namespace LMSSolution.ViewModels.Subject
{
    public class SubjectCreateRequest
    {
        public string? Name { get; set; }
        public int? NumberOfLesson { get; set; }
        public List<int>? MajorId { get; set; }  = new List<int>();
    }
}
