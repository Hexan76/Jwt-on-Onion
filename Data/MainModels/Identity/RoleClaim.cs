public class RoleClaim
{
#nullable disable
    public Guid RoleID { get; set; }
    public string Name { get; set; }
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
    public virtual Role Role { get; set; }

}
