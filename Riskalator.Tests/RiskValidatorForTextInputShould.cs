using Microsoft.VisualStudio.TestTools.UnitTesting;
using Riskalator.Models;

namespace Riskalator.Tests
{
    [TestClass]
    public class RiskValidatorForTextInputShould
    {
        private RiskIndicators _riskIndicators;

        [TestInitialize]
        public void Setup()
        {
            _riskIndicators = new RiskIndicators
            {
                Safety = "Above Peer",
                Warning = "Peer",
                Escalation = "Below Peer"
            };
        }

        [TestMethod]
        public void Return_Safety_When_SelectionMatchesSafetyCondition()
        {
            var validator = RiskValidator.Create(_riskIndicators, "Above Peer");

            var result = validator.Validate();

            Assert.AreEqual(result, RiskIndicatorType.Safety);
        }

        [TestMethod]
        public void Return_Warning_When_SelectionMatchesWarningCondition()
        {
            var validator = RiskValidator.Create(_riskIndicators, "Peer");

            var result = validator.Validate();

            Assert.AreEqual(result, RiskIndicatorType.Warning);
        }

        [TestMethod]
        public void Return_Escalation_When_SelectionMatchesEscalationCondition()
        {
            var validator = RiskValidator.Create(_riskIndicators, "Below Peer");

            var result = validator.Validate();

            Assert.AreEqual(result, RiskIndicatorType.Escalation);
        }

        [TestMethod]
        public void Return_Escalation_When_SelectionMatchesNoCondition()
        {
            var validator = RiskValidator.Create(_riskIndicators, "Random Text 101");

            var result = validator.Validate();

            Assert.AreEqual(result, RiskIndicatorType.Escalation);
        }
    }
}