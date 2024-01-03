namespace LMSSolution.ViewModels.System.User
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public GenderEnum Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Dob { get; set; }
    }

    public enum GenderEnum
    {
        Female,
        Male,
        Unknown,
    }
}
