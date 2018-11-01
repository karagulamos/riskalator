using Riskalator.Models;
using Riskalator.Patterns;
using System.Collections.Generic;

namespace Riskalator
{
    public class RiskValidator
    {
        private readonly string _pattern;
        private readonly string _selection;

        private readonly Dictionary<string, string> _indicatorValues;

        protected RiskValidator(RiskIndicators indicators, IRiskPattern pattern, string selection)
        {
            _pattern = pattern.GetPattern();

            _selection = selection.ToLower();

            _indicatorValues = new Dictionary<string, string>
            {
                {nameof(RiskIndicators.Safety), indicators.Safety.ToLower()},
                {nameof(RiskIndicators.Warning), indicators.Warning.ToLower()},
                {nameof(RiskIndicators.Escalation), indicators.Escalation.ToLower()}
            };
        }

        public virtual RiskIndicatorType Validate()
        {
            foreach (var indicatorType in IndicatorTypes.Keys)
            {
                var indicatorValue = _indicatorValues[indicatorType];

                var tokens = RiskValueParser.ParseTokens(indicatorValue, _pattern);
                var rule = RiskRuleFactory.CreateRule(tokens, indicatorValue);

                if (rule.IsValidFor(_selection))
                {
                    return IndicatorTypes[indicatorType];
                }
            }

            return RiskIndicatorType.Escalation;
        }

        public static RiskValidator Create(RiskIndicators indicators,  string selection)
        {
            var pattern = RiskPatternFactory.CreatePattern(selection);
            return new RiskValidator(indicators, pattern, selection);
        }

        private static readonly Dictionary<string, RiskIndicatorType> IndicatorTypes =
        new Dictionary<string, RiskIndicatorType>
        {
            {nameof(RiskIndicators.Safety), RiskIndicatorType.Safety},
            {nameof(RiskIndicators.Warning), RiskIndicatorType.Warning},
            {nameof(RiskIndicators.Escalation), RiskIndicatorType.Escalation}
        };
    }
}