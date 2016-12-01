using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    class Intitalizer
    {
        public static Context db;

        static Intitalizer()
        {
            db = new Context();
        }
        static void Main()
        {
            if (!Database.Exists("LibraryDatabase"))
                db.Seed();
        }
    }
}
