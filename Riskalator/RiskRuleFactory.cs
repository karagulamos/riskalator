using System;
using Riskalator.Models;
using Riskalator.Rules;

namespace Riskalator
{
    public class RiskRuleFactory
    {
        public static IRiskRule CreateRule(RiskValueToken[] valueTokens, string indicator)
        {
            switch ((RiskRuleType)valueTokens.Length)
            {
                case RiskRuleType.DefaultTextRule:
                    return new DefaultTextRiskRule(indicator);
                case RiskRuleType.SingleValueRule:
                    return new SingleValueRiskRule(valueTokens[0]);
                case RiskRuleType.RangeValueRule:
                    return new RangeValueRiskRule(valueTokens[0], valueTokens[1]);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
