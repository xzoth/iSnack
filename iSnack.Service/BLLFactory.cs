using Spring.Context;
using Spring.Context.Support;
using System.Collections;

namespace iSnack.Service
{
    public static class BLLFactory
    {
        public static IApplicationContext context = ContextRegistry.GetContext();

        public static T GetBLLByKey<T>(string str) where T : class
        {
            return context.GetObject(str) as T;
        }

        public static T GetBLLByType<T>() where T : class
        {
            T bll = default(T);

            IDictionary bllDic = context.GetObjectsOfType(typeof(T));
            foreach (DictionaryEntry item in bllDic)
            {
                bll = item.Value as T;
                break;
            }

            return bll;
        }
    }
}
