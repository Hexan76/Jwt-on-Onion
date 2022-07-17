using Microsoft.AspNetCore.Authorization;

public class PAuthorizeAttribute : AuthorizeAttribute
{
    public const string Prefix = "PERMISSION:";
    public PAuthorizeAttribute(params string[] permissions)
    {
        Policy = $"{Prefix}{string.Join(",", permissions)}";
    }
}