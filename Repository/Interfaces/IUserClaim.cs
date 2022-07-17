public interface IUserClaim
{
    bool Create(UserClaim userClaim);
    bool Delete(UserClaim userClaim);
    UserClaim Find(Guid userID);

}