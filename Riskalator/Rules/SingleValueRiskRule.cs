using Riskalator.Models;
using System;

namespace Riskalator.Rules
{
    public class SingleValueRiskRule : BaseValueRiskRule, IRiskRule
    {
        private readonly RiskValueToken _token;

        public SingleValueRiskRule(RiskValueToken token)
        {
            _token = token;
        }

        public bool IsValidFor(string selection)
        {
            return IsValid(Convert.ToDecimal(selection), _token.Operation, _token.AcceptableValue);
        }
    }
}