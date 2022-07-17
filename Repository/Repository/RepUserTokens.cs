using Repository.Interfaces;

public class RepUserTokens : IUserTokens
{
    private readonly ICRUD _crud;

    public RepUserTokens(ICRUD crud)
    {
        _crud = crud;
    }

    public bool Create(UserToken userToken)
    {
        var existToken = Find(userToken.UserID);
        if (existToken != null) return false;

        _crud.Create(userToken);

        return true;
    }

    public bool Delete(UserToken userToken)
    {
        var existToken = Find(userToken.UserID);
        if (existToken != null) return false;

        _crud.Delete(userToken);

        return true;
    }

    public UserToken Find(Guid userID)
    {
        var existToken = _crud.Get<UserToken>(u => u.UserID == userID);
        return existToken;
    }
}
