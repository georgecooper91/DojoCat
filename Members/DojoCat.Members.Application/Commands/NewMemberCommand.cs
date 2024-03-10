using DojoCat.Members.Domain.Models;

namespace DojoCat.Members.Application.Commands;

public class NewMemberCommand
{
    public NewMemberCommand(Member member /*user details here*/)
    {
        Member = member;
    }

    public Member Member { get; } 
}
