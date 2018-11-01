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

        protected RiskValidator(Indicators indicators, IRiskPattern pattern, string selection)
        {
            _pattern = pattern.GetPattern();

            _selection = selection;

            _indicatorValues = new Dictionary<string, string>
            {
                {nameof(Indicators.Safety), indicators.Safety},
                {nameof(Indicators.Warning), indicators.Warning},
                {nameof(Indicators.Escalation), indicators.Escalation}
            };
        }

        public virtual RiskIndicatorType Validate()
        {
            foreach (var indicatorType in IndicatorTypes.Keys)
            {
                var indicatorValue = _indicatorValues[indicatorType];

                var tokens = RiskValueParser.ParseTokens(indicatorValue, _pattern);
                var rule = RiskRuleFactory.CreateRule(tokens, indicatorValue);

                if (rule.IsValid(_selection))
                {
                    return IndicatorTypes[indicatorType];
                }
            }

            return RiskIndicatorType.Escalation;
        }

        public static RiskValidator Create(Indicators indicators,  string selection)
        {
            var pattern = RiskPatternFactory.CreatePattern(selection);
            return new RiskValidator(indicators, pattern, selection);
        }

        private static readonly Dictionary<string, RiskIndicatorType> IndicatorTypes =
        new Dictionary<string, RiskIndicatorType>
        {
            {nameof(Indicators.Safety), RiskIndicatorType.Safety},
            {nameof(Indicators.Warning), RiskIndicatorType.Warning},
            {nameof(Indicators.Escalation), RiskIndicatorType.Escalation}
        };
    }
}