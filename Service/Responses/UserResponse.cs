public class UserResponse : BaseResponse
{
    public UserResponse(bool success, string message, User user = null, ICollection<User> users = null) : base(success, message)
    {
        User = user;
        Users = users;
    }
    public User User { get; set; }
    public ICollection<User> Users { get; set; }


}