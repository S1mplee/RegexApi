namespace Exercice.Singelton
{
    public class Singelton
    {
        private static Singelton _instance = null;
        private static readonly object _lock = new object();
        private Singelton()
        {

        }

        public static Singelton GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new Singelton();

                return _instance;
            }
        }
    }
}
