public class UserToken
{
#nullable disable
    public Guid UserID { get; set; }
    public string Value { get; set; }
    //public virtual Provider ProviderID { get; set; }
    public virtual User User { get; set; }
}
