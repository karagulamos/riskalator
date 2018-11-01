namespace Riskalator.Rules
{
    public interface IRiskRule
    {
        bool IsValidFor(string selection);
    }
}