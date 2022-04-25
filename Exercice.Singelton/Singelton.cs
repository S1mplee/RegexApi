namespace Exercice.Singelton
{
    public class Singelton
    {
        private static Singelton _instance = null;

        private Singelton()
        {

        }

        public static Singelton GetInstance()
        {
            if (_instance == null)
                _instance = new Singelton();

            return _instance;
        }
    }
}
