using Repository.Interfaces;

namespace Repository.Repository
{
    public class RepUser : IUser
    {
        private ICRUD _crud;
        public RepUser(ICRUD crud)
        {
            _crud = crud;
        }
        public bool Create(User user)
        {
            var existingUser = Find(user.ID);
            if (existingUser != null) return false;

            _crud.Create(user);

            return true;
        }
        public bool Delete(User user)
        {
            var existingUser = Find(user.UserName);
            if (existingUser == null) return false;

            _crud.Delete(existingUser);

            return true;
        }
        public bool Delete(Guid guidUser)
        {
            var existingUser = Find(guidUser);
            if (existingUser == null) return false;

            _crud.Delete(existingUser);

            return true;
        }
        public User Find(string userName)
        {
            var existingUser = _crud.Get<User>(u => u.UserName.Equals(userName.Trim()));
            return existingUser;
        }
        public User FindByEmail(string email)
        {
            var existingUser = _crud.Get<User>(u => u.Email.Equals(email.Trim()));
            return existingUser;
        }
        public User Find(Guid guidUser)
        {
            var existingUser = _crud.Get<User>(u => u.ID == guidUser);
            return existingUser;
        }
        public ICollection<User> GetAll()
        {
            return _crud.GetAll<User>();
        }
        public ICollection<User> GetPageList(int pagesize = 10, int pageindex = 1)
        {
            var pageList = _crud.GetPageList<User>(pagesize, pageindex, x => x.OrderBy(u => u.UserName));
            return pageList;
        }
#nullable disable
        public bool Update(User oldUser, User newUser)
        {
            var existingUser = Find(oldUser.ID);
            if (existingUser == null) return false;

            oldUser = newUser.Clone() as User;

            _crud.Update(oldUser);
            return true;

        }
        public bool Update(User user)
        {
            var existingUser = Find(user.ID);
            if (existingUser == null) return false;

            _crud.Update(user);
            return true;

        }
#nullable enable
    }
}
