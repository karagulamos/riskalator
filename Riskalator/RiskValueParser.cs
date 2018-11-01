using Riskalator.Models;
using System;
using System.Text.RegularExpressions;

namespace Riskalator
{
    public class RiskValueParser
    {
        public static RiskValueToken[] ParseTokens(string indicatorValue, string pattern)
        {
            var matches = Regex.Matches(indicatorValue, pattern, RegexOptions.ECMAScript | RegexOptions.IgnoreCase);

            if (matches.Count == 0 || matches[0].Groups.Count == 1)
                return new RiskValueToken[0];

            var groups = matches[0].Groups;

            var operation1 = groups[1].Value;
            var acceptableValue1 = groups[2].Value.Replace(",", string.Empty);

            var operation2 = groups[3].Value;
            var acceptableValue2 = groups[4].Value.Replace(",", string.Empty);

            if (string.IsNullOrEmpty(acceptableValue2))
            {
                return new[]
                {
                    new RiskValueToken(operation1, Convert.ToDecimal(acceptableValue1))
                };
            }

            return new[]
            {
                new RiskValueToken(operation1, Convert.ToDecimal(acceptableValue1)),
                new RiskValueToken(operation2, Convert.ToDecimal(acceptableValue2))
            };
        }
    }
}
