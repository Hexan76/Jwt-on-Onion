public class UserCreateDTO
{
    public string UserName { get; set; }

    public string Password { get; set; }
    public string ConfirmPass { get; set; }
    public bool IsActive { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }


}