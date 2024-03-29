using DojoCat.Members.Common.User;
using DojoCat.Members.Domain.Models;

namespace DojoCat.Members.Application.Commands;

public class NewMemberCommand
{
    public NewMemberCommand(Member member)
    {
        Member = member;
    }

    public Member Member { get; }
}
