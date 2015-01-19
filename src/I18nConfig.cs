using System;
using System.Reflection;
using System.Resources;

namespace i18n.Extension
{
    public static class I18nConfig
    {
        public static II18nLookupFailedStrategy LookupFailedStrategy = new IgnoreI18nLookupFailedStrategy();
        public static ResourceManager[] Resources { get; private set; }

        public static void SetResources(params Type[] types)
        {
            if (types == null)
                types = new Type[0];

            ResourceManager[] resources = new ResourceManager[types.Length];
            for (int i = 0; i < types.Length; i++)
            {
                PropertyInfo resourceProperty = types[i].GetProperty("ResourceManager", BindingFlags.Static | BindingFlags.NonPublic);
                if (resourceProperty == null)
                    throw new Exception(string.Format("Type '{0}' is not a resource class", types[i].Name));

                ResourceManager resx = resourceProperty.GetValue(null, null) as ResourceManager;
                resources[i] = resx;
            }

            SetResources(resources);
        }

        public static void SetResources(params ResourceManager[] resources)
        {
            if (resources == null)
                resources = new ResourceManager[0];

            I18nConfig.Resources = resources;
        }
    }
}
