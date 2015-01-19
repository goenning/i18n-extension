using System;

namespace i18n.Extension
{
    public class ThrowExceptionI18nLookupFailedStrategy : II18nLookupFailedStrategy
    {
        public string HandleIt(string text, string[] keys)
        {
            string message = string.Format("Translation not found for text '{0}'. None of the following keys was found in the resources files: {1}", text, string.Join(" , ", keys));
            throw new Exception(message);
        }
    }
}
