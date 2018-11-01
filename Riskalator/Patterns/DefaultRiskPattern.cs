namespace Riskalator.Patterns
{
    public class DefaultRiskPattern : IRiskPattern
    {
        private readonly string _selection;

        public DefaultRiskPattern(string selection)
        {
            _selection = selection;
        }

        public string GetPattern()
        {
            return _selection;
        }
    }
}