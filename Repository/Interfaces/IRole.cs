public interface IRole
{
    bool Create(Role role);
    bool Update(Role role);
    bool Delete(Role role);
    Role Find(string rolename);
    Role Find(Guid guidRole);
    ICollection<Role> GetAll();
    ICollection<Role> GetPageList(int pagesize, int pageindex);

}