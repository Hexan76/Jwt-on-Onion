namespace Repository.Interfaces
{
    public interface IUser
    {
        bool Create(User user);
        bool Delete(User user);
        bool Delete(Guid guidUser);
        User Find(string userNames);
        User FindByEmail(string email);
        User Find(Guid guidUser);
        ICollection<User> GetAll();
        ICollection<User> GetPageList(int pagesize, int pageindex);
        bool Update(User user);
        bool Update(User oldUser, User newUser);

    }
}
