using System.Security.Claims;

namespace DojoCat.Members.Common.User;

public class DojoCatUser
{
    public DojoCatUser()
    {
        
    }
    public DojoCatUser(ClaimsPrincipal claims)
    {
        if(claims is not null)
        {
            SetUser(claims);
        }
    }

    private void SetUser(ClaimsPrincipal claims)
    {
        // TODO: implement this when integrated with auth service
    }
}
