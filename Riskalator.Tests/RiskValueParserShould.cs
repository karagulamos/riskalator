using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Riskalator.Tests
{
    [TestClass]
    public class RiskValueParserShould
    {
        [TestMethod]
        public void Return_ListWithOneItem_For_SingleValueMatch()
        {
            var pattern = RiskPatternFactory.CreatePattern("44444");

            var valueTokens1 = RiskValueParser.ParseTokens("400000", pattern.GetPattern());
            var valueTokens2 = RiskValueParser.ParseTokens("400000%", pattern.GetPattern());
            var valueTokens3 = RiskValueParser.ParseTokens(">400000", pattern.GetPattern());
            var valueTokens4 = RiskValueParser.ParseTokens("<=400000", pattern.GetPattern());

            Assert.AreEqual(valueTokens1.Length, 1);
            Assert.AreEqual(valueTokens2.Length, 1);
            Assert.AreEqual(valueTokens3.Length, 1);
            Assert.AreEqual(valueTokens4.Length, 1);
        }

        [TestMethod]
        public void Return_ListWithTwoItems_For_RangeValueMatch()
        {
            var pattern = RiskPatternFactory.CreatePattern("300%");

            var valueTokens1 = RiskValueParser.ParseTokens("4000 - 50000", pattern.GetPattern());
            var valueTokens2 = RiskValueParser.ParseTokens("100% - 500%", pattern.GetPattern());
            var valueTokens3 = RiskValueParser.ParseTokens("<4000 - 50000", pattern.GetPattern());
            var valueTokens4 = RiskValueParser.ParseTokens(">4000 - <=60000", pattern.GetPattern());

            Assert.AreEqual(valueTokens1.Length, 2);
            Assert.AreEqual(valueTokens2.Length, 2);
            Assert.AreEqual(valueTokens3.Length, 2);
            Assert.AreEqual(valueTokens4.Length, 2);
        }

        [TestMethod]
        public void Return_ListWithZeroItems_For_DefaultTextMatch()
        {
            var pattern = RiskPatternFactory.CreatePattern("Default Alphabetic Text");

            var valueTokens1 = RiskValueParser.ParseTokens("4000", pattern.GetPattern());
            var valueTokens2 = RiskValueParser.ParseTokens("40000 - 50000", pattern.GetPattern());

            Assert.AreEqual(valueTokens1.Length, 0);
            Assert.AreEqual(valueTokens2.Length, 0);
        }
    }
}
