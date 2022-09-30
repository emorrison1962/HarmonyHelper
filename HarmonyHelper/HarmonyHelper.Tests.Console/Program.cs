using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHelper.Tests.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Program().MainImpl();
        }

        private void MainImpl()
        {
            new TestRunner().Run();
        }
    }
}
