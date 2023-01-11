using Eric.Morrison;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HarmonyHelper.Tests.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestUtilities.DisableAssertionDialogs();
            new Program().MainImpl();
            Debug.WriteLine("Finito!!!");
        }

        private void MainImpl()
        {
            new TestRunner().Run();
        }
    }
}
