namespace Adopet.Console.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class CommandAttribute(string command, string documentation) : Attribute
{
    public string Command { get; } = command;
    public string Documentation { get; } = documentation;
}
