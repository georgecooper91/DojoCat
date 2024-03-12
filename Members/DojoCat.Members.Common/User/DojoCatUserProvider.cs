using Microsoft.AspNetCore.Http;

namespace DojoCat.Members.Common.User;

public class DojoCatUserProvider
{
    private readonly IHttpContextAccessor _context;
    public DojoCatUser User => new DojoCatUser(_context.HttpContext.User);

    public DojoCatUserProvider(IHttpContextAccessor context)
    {
        _context = context;
    }
}
