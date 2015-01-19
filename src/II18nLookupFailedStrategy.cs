
namespace i18n.Extension
{
    public interface II18nLookupFailedStrategy
    {
        string HandleIt(string text, string[] keys);
    }
}
