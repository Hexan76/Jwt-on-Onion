using Repository.Interfaces;
public class RepRole : IRole
{
    private ICRUD _crud;

    public RepRole(ICRUD crud)
    {
        _crud = crud;
    }

    public bool Create(Role role)
    {
        var existRole = Find(role.ID);
        if (existRole != null) return false;

        _crud.Create(role);

        return true;

    }

    public bool Delete(Role role)
    {
        var existRole = Find(role.ID);
        if (existRole == null) return false;

        _crud.Delete(role);

        return true;
    }

    public Role Find(string rolename)
    {
        var existRole = _crud.Get<Role>(u => u.RoleName.Equals(rolename.Trim()));
        return existRole;
    }

    public Role Find(Guid guidRole)
    {
        var existRole = _crud.Get<Role>(u => u.ID == guidRole);
        return existRole;
    }

    public ICollection<Role> GetAll()
    {
        return _crud.GetAll<Role>();
    }

    public ICollection<Role> GetPageList(int pagesize, int pageindex)
    {
        var pageList = _crud.GetPageList<Role>(pagesize, pageindex, x => x.OrderBy(u => u.RoleName));
        return pageList;
    }

    public bool Update(Role role)
    {
        var existRole = Find(role.ID);
        if (existRole == null) return false;

        _crud.Update(role);
        return true;
    }
}
