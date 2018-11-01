using System.Text.RegularExpressions;
using Riskalator.Patterns;

namespace Riskalator
{
    public class RiskPatternFactory
    {
        public static IRiskPattern CreatePattern(string selection)
        {
            if (Regex.IsMatch(selection, @"[\d]"))
                return new ValueRiskPattern();

            return new DefaultRiskPattern(selection);
        }
    }
}