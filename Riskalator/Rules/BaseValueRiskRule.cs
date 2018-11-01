namespace Riskalator.Rules
{
    public abstract class BaseValueRiskRule
    {
        protected bool IsValid(decimal inputtedValue, string operation, decimal acceptableValue)
        {
            switch (operation)
            {
                case ">":
                    return inputtedValue > acceptableValue;
                case "<":
                    return inputtedValue < acceptableValue;
                case ">=":
                    return inputtedValue >= acceptableValue;
                case "<=":
                    return inputtedValue <= acceptableValue;
                default:
                    return inputtedValue <= acceptableValue;
            }
        }
    }
}