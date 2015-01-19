
namespace i18n.Extension
{
    public class FormatTextI18nLookupFailedStrategy : II18nLookupFailedStrategy
    {
        public string Prepend { get; private set; }
        public string Append { get; private set; }

        public FormatTextI18nLookupFailedStrategy(string prepend, string append)
        {
            this.Prepend = prepend;
            this.Append = append;
        }

        public string HandleIt(string text, string[] keys)
        {
            return string.Concat(this.Prepend, text, this.Append);
        }
    }
}
