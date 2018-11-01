namespace Riskalator.Patterns
{
    public class ValueRiskPattern : IRiskPattern
    {
        public string GetPattern()
        {
            return @"^\s*(?:([<>]?[=]?)\(?([ \d.,]+)%?\)?)\s*(?:to|-)?\s*(?:([<>]?[=]?)\(?([ \d.,]+)%?\)?)?\s*$";
        }
    }
}