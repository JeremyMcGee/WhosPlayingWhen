namespace FixtureScanner
{
    using Scanner;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Logger.CurrentLevel = Logger.Level.Debug;

            Site site = new Site();
            site.Initialize();
            site.Scan();

            Logger.Info("Done.");
        }
    }
}
