using Repository.Interfaces;

public class RepRoleClaim : IRoleClaim
{
    private readonly ICRUD _crud;

    public RepRoleClaim(ICRUD crud)
    {
        _crud = crud;
    }

    public bool Create(RoleClaim roleClaim)
    {
        var existclaim = Find(roleClaim.RoleID);
        if (existclaim != null) return false;

        _crud.Create(roleClaim);

        return true;
    }

    public bool Delete(RoleClaim roleClaim)
    {
        var existclaim = Find(roleClaim.RoleID);
        if (existclaim != null) return false;

        _crud.Delete(roleClaim);

        return true;
    }

    public RoleClaim Find(Guid roleID)
    {
        var existclaim = _crud.Get<RoleClaim>(u => u.RoleID == roleID);
        return existclaim;
    }
}