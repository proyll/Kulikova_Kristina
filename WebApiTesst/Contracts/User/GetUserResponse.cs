namespace WebApiTesst.Contracts.User
{
    public class GetUserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? UserEmail { get; set; }
        public string UserRole { get; set; } = null!;
        public string UserPassord { get; set; } = null!;
    }
}
