namespace Riskalator.Rules
{
    public interface IRiskRule
    {
        bool IsValid(string selection);
    }
}