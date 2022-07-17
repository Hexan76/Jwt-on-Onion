public class UserClaim
{
#nullable disable
    public Guid UserID { get; set; }
    public string Name { get; set; }
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
    public virtual User User { get; set; }
}
