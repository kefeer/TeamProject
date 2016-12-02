using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                db.Seed();
        }
    }
}
