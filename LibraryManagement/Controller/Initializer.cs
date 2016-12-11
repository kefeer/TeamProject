using System.Data.Entity;


namespace Controller
{
    public class Initializer
    {
        public static Context db;

        static Initializer()
        {
            db = new Context();
        }

        public static void Main()
        {
            if (!Database.Exists("LibraryDatabase"))
                Database.SetInitializer(new MyInitializer());
        }
    }
}
