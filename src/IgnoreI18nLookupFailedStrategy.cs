
namespace i18n.Extension
{
    public class IgnoreI18nLookupFailedStrategy : II18nLookupFailedStrategy
    {
        public string HandleIt(string text, string[] keys)
        {
            return text;
        }
    }
}
