using System.Data.SqlTypes;

namespace SingletonLib
{
    public interface ISingleton<T>
    {
        internal protected static abstract T initilize();
    }
    public abstract class Singleton<T> where T : class, ISingleton<T>
    {
        private static T? instance;
        private static readonly object padlock = new object();

        public static T Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null) { instance = T.initilize(); }
                    return instance;
                }
            }
        }
    }
}