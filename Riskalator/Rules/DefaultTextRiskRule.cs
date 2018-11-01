namespace Riskalator.Rules
{
    public class DefaultTextRiskRule : IRiskRule
    {
        private readonly string _indicatorValue;

        public DefaultTextRiskRule(string indicatorValue)
        {
            _indicatorValue = indicatorValue;
        }

        public bool IsValidFor(string selection)
        {
            return _indicatorValue == selection;
        }
    }
}
