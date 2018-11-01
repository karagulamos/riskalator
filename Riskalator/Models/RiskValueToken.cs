namespace Riskalator.Models
{
    public struct RiskValueToken
    {
        public RiskValueToken(string operation, decimal acceptableValue)
        {
            Operation = operation;
            AcceptableValue = acceptableValue;
        }

        public string Operation { get; }
        public decimal AcceptableValue { get; }
    }
}
