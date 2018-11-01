using System;
using Riskalator.Models;

namespace Riskalator.Rules
{
    public class RangeValueRiskRule : BaseValueRiskRule, IRiskRule
    {
        private readonly RiskValueToken _token1;
        private readonly RiskValueToken _token2;

        public RangeValueRiskRule(RiskValueToken token1, RiskValueToken token2)
        {
            _token1 = token1;
            _token2 = token2;
        }

        public bool IsValid(string selection)
        {
            var inputtedValue = Convert.ToDecimal(selection);

            return IsValid(inputtedValue, _token1.Operation, _token1.AcceptableValue)
                && IsValid(inputtedValue, _token2.Operation, _token2.AcceptableValue);
        }
    }
}