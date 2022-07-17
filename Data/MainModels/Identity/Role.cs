using Data.Common;

public class Role : BaseModel
{
#nullable disable
    public string RoleName { get; set; }
    public string Description { get; set; }
    public virtual ICollection<User> Users { get; set; }
    //public virtual ICollection<UserRole> UserRole { get; set; }
    public virtual List<RoleClaim> Claims { get; set; }
#nullable disable
    public enum BasicRoles
    {
        Administrator,
        Developer,
        StageTester,
        Producer,
        NormalUser

    }

}
