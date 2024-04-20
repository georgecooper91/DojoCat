using DojoCat.Members.Domain.Models;

namespace DojoCat.Members.Application.Commands;

public class NewParentCommand
{
    public NewParentCommand(Parent parent)
    {
        Parent = parent;
    }

    public Parent Parent { get; }
}
