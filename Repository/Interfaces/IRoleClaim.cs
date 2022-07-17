public interface IRoleClaim
{
    bool Create(RoleClaim roleClaim);
    bool Delete(RoleClaim roleClaim);
    RoleClaim Find(Guid roleID);

}