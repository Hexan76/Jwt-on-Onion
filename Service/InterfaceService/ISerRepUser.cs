namespace Service.InterfaceService
{
    public interface ISerRepUser
    {
        Task<UserResponse> CreateUserAsync(User user);
        Task<UserResponse> GetUserByEmailAsync(string email);
        Task<UserResponse> GetUserByGUIDAsync(Guid guid);
        Task<UserResponse> GetUserbyUserNameAsync(string userName);
        Task<UserResponse> GetUsersAsync();
        Task<UserResponse> GetUsersByPageAsync(int pagesize = 10, int pageindex = 1);
        Task<UserResponse> DeleteUserAsync(User user);
        Task<UserResponse> DeleteUserByGuidAsync(Guid guiduser);
        Task<UserResponse> DeleteUserByEmailAsync(string email);

    }
}
