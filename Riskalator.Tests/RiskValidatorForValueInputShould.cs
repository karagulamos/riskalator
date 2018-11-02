using Microsoft.VisualStudio.TestTools.UnitTesting;
using Riskalator.Models;

namespace Riskalator.Tests
{
    [TestClass]
    public class RiskValidatorForValueInputShould
    {
        private RiskIndicators _riskIndicators;

        [TestInitialize]
        public void Setup()
        {
            _riskIndicators = new RiskIndicators
            {
                Safety = "<(300,000)",
                Warning = ">(300,000) to (323,000)",
                Escalation = ">(323,000)"
            };
        }

        [TestMethod]
        public void Return_Safety_When_SelectionMatchesSafetyCondition()
        {
            var validator = RiskValidator.Create(_riskIndicators, "50000");

            var result = validator.Validate();

            Assert.AreEqual(result, RiskIndicatorType.Safety);
        }

        [TestMethod]
        public void Return_Warning_When_SelectionMatchesWarningCondition()
        {
            var validator = RiskValidator.Create(_riskIndicators, "300001");

            var result1 = validator.Validate();
            
            validator = RiskValidator.Create(_riskIndicators, "323000");

            var result2 = validator.Validate();

            Assert.AreEqual(result1, RiskIndicatorType.Warning);
            Assert.AreEqual(result2, RiskIndicatorType.Warning);
        }

        [TestMethod]
        public void Return_Escalation_When_SelectionMatchesEscalationCondition()
        {
            var validator = RiskValidator.Create(_riskIndicators, "323,001");

            var result = validator.Validate();

            Assert.AreEqual(result, RiskIndicatorType.Escalation);
        }

        [TestMethod]
        public void Return_Escalation_When_SelectionMatchesNoCondition()
        {
            var validator = RiskValidator.Create(_riskIndicators, "300,000");

            var result = validator.Validate();

            Assert.AreEqual(result, RiskIndicatorType.Escalation);
        }
    }
}
