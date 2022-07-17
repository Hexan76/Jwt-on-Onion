using Data.Common;
using System.Text.Json.Serialization;

public class User : BaseModel, ICloneable
{
#nullable disable
    public string UserName { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
    public bool IsActive { get; set; } = true;
    public bool TwoFactorAuthenticator { get; set; }
#nullable enable
    public string? Email { get; set; }
    public string? EmailConfirm { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PhoneNumberConfirm { get; set; }



#nullable disable
    //public virtual PersonInfo Information { get; set; }
    public virtual ICollection<Role> Roles { get; set; }
    // public virtual ICollection<UserRole> UserRole { get; set; }
    public virtual ICollection<UserClaim> Claims { get; set; }
    public virtual ICollection<UserToken> Tokens { get; set; }
#nullable enable

    public object Clone()
    {
        User user = (User)this.MemberwiseClone();
        user.Roles = (ICollection<Role>)this.MemberwiseClone();
        user.Claims = (ICollection<UserClaim>)this.MemberwiseClone();
        return user;
    }
}
