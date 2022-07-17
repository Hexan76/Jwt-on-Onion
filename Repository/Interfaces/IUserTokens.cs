public interface IUserTokens
{
    bool Create(UserToken userToken);
    bool Delete(UserToken userToken);
    UserToken Find(Guid userID);

}