using System.ComponentModel;
using System.Data.SqlTypes;

namespace SingletonLib
{
    public interface ISingleton<T>
    {
        internal protected static abstract T initilize();
        public int Foo() { return 1; }


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

    public interface ISingleton2<T> where T : ISingleton2<T>
    {
        private static readonly object padlock = new object();
        private static T? instance;
        internal protected static abstract T initialize();
        static T getInstance()
        {
            lock (padlock)
            {
                if (instance == null) instance = T.initialize();
                return instance;
            }
        }
    }
    
}