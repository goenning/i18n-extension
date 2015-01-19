using i18n.Extension;
using System.Resources;

namespace System
{
    public static class I18nExtension
    {
        public static string i18n(this object value)
        {
            if (value is Enum)
                return i18n(value as Enum);

            return i18n(value as string);
        }

        public static string i18n(this string text)
        {
            string key = FormatResourceKey(text);
            return Translate(text, new string[] { key });
        }

        public static string i18n(this Enum value)
        {
            string[] keys = new string[] { 
                string.Format("{0}_{1}", value.GetType().Name, FormatResourceKey(value.ToString())),
                string.Format("{0}_{1}", value.GetType().Name, FormatResourceKey(value.GetHashCode().ToString())),
                FormatResourceKey(value.ToString())
            };

            return Translate(value.ToString(), keys);
        }

        private static string FormatResourceKey(string key)
        {
            if (string.IsNullOrEmpty(key))
                return null;

            return key.Replace(" ", "_");
        }

        private static string Translate(string text, string[] keys)
        {
            foreach (string key in keys)
            {
                foreach (ResourceManager resx in I18nConfig.Resources)
                {
                    if (string.IsNullOrEmpty(key))
                        return string.Empty;

                    string i18nText = resx.GetString(key);
                    if (i18nText != null)
                        return i18nText;
                }
            }

            return I18nConfig.LookupFailedStrategy.HandleIt(text, keys);
        }
    }
}
