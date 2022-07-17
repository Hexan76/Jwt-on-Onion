using Repository.Interfaces;

public class RepUserClaim : IUserClaim
{
    private readonly ICRUD _crud;

    public RepUserClaim(ICRUD crud)
    {
        _crud = crud;
    }

    public bool Create(UserClaim userClaim)
    {
        var existclaim = Find(userClaim.UserID);
        if (existclaim != null) return false;

        _crud.Create(userClaim);

        return true;
    }

    public bool Delete(UserClaim userClaim)
    {
        var existclaim = Find(userClaim.UserID);
        if (existclaim != null) return false;

        _crud.Delete(userClaim);

        return true;
    }

    public UserClaim Find(Guid userID)
    {
        var existclaim = _crud.Get<UserClaim>(u => u.UserID == userID);
        return existclaim;
    }
}
