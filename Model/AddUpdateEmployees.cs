namespace DotNet8WebAPI.Model
{
    public class AddUpdateEmployees
    {
        public required string Name { get; set; }
        public string Dob {  get; set; } = string.Empty;
        public string Salary { get; set; } = string.Empty;
        public bool isActive {  get; set; }

    }
}
