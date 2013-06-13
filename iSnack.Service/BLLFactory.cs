using iSnack.BLL.Interface;
using Spring.Context;
using Spring.Context.Support;
using System.Collections;

namespace iSnack.Service
{
    public static class BLLFactory
    {
        public static IApplicationContext context;

        static BLLFactory()
        {
            context = ContextRegistry.GetContext();
        }

        public static T GetBLLByKey<T>(string str) where T : class, IBaseBLL
        {
            return context.GetObject(str) as T;
        }

        public static T GetBLLByType<T>() where T : class, IBaseBLL
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
