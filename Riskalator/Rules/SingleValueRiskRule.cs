using System;
using Riskalator.Models;

namespace Riskalator.Rules
{
    public class SingleValueRiskRule : BaseValueRiskRule, IRiskRule
    {
        private readonly RiskValueToken _token;

        public SingleValueRiskRule(RiskValueToken token)
        {
            _token = token;
        }

        public bool IsValid(string selection)
        {
            return IsValid(Convert.ToDecimal(selection), _token.Operation, _token.AcceptableValue);
        }
    }
}