using Microsoft.VisualStudio.TestTools.UnitTesting;
using Riskalator.Models;

namespace Riskalator.Tests
{
    [TestClass]
    public class RiskValidatorShould
    {
        private Indicators _valueIndicators;
        private Indicators _textIndicators;

        [TestInitialize]
        public void Setup()
        {
            _valueIndicators = new Indicators
            {
                Safety = "<(300,000)",
                Warning = ">(300,000) to (323,000)",
                Escalation = ">(323,000)"
            };

            _textIndicators = new Indicators
            {
                Safety = "Above Peer",
                Warning = "Peer",
                Escalation = "Below Peer"
            };
        }

        [TestMethod]
        public void Return_Safety_When_ValueSelectionMatchesSafetyCondition()
        {
            const string selection = "50000";

            var validator = RiskValidator.Create(_valueIndicators, selection);

            var result = validator.Validate();

            Assert.AreEqual(result, RiskIndicatorType.Safety);
        }

        [TestMethod]
        public void Return_Warning_When_ValueSelectionMatchesWarningCondition()
        {
            var selection = "300001";
            
            var validator = RiskValidator.Create(_valueIndicators, selection);

            var result1 = validator.Validate();

            selection = "323000";

            validator = RiskValidator.Create(_valueIndicators, selection);

            var result2 = validator.Validate();

            Assert.AreEqual(result1, RiskIndicatorType.Warning);
            Assert.AreEqual(result2, RiskIndicatorType.Warning);
        }

        [TestMethod]
        public void Return_Escalation_When_ValueSelectionMatchesEscalationCondition()
        {
            const string selection = "323,001";
            
            var validator = RiskValidator.Create(_valueIndicators, selection);

            var result = validator.Validate();

            Assert.AreEqual(result, RiskIndicatorType.Escalation);
        }

        [TestMethod]
        public void Return_Escalation_When_ValueSelectionMatchesNoCondition()
        {
            const string selection = "300,000";
            
            var validator = RiskValidator.Create(_valueIndicators, selection);

            var result = validator.Validate();

            Assert.AreEqual(result, RiskIndicatorType.Escalation);
        }

        [TestMethod]
        public void Return_Safety_When_TextSelectionMatchesSafetyCondition()
        {
            const string selection = "Above Peer";
            
            var validator = RiskValidator.Create(_textIndicators, selection);

            var result = validator.Validate();

            Assert.AreEqual(result, RiskIndicatorType.Safety);
        }

        [TestMethod]
        public void Return_Warning_When_TextSelectionMatchesWarningCondition()
        {
            const string selection = "Peer";
            
            var validator = RiskValidator.Create(_textIndicators, selection);

            var result = validator.Validate();

            Assert.AreEqual(result, RiskIndicatorType.Warning);
        }

        [TestMethod]
        public void Return_Escalation_When_TextSelectionMatchesEscalationCondition()
        {
            const string selection = "Below Peer";
            
            var validator = RiskValidator.Create(_textIndicators, selection);

            var result = validator.Validate();

            Assert.AreEqual(result, RiskIndicatorType.Escalation);
        }


        [TestMethod]
        public void Return_Escalation_When_TextSelectionMatchesNoCondition()
        {
            const string selection = "Random Text 101";
            
            var validator = RiskValidator.Create(_textIndicators, selection);

            var result = validator.Validate();

            Assert.AreEqual(result, RiskIndicatorType.Escalation);
        }
    }
}
