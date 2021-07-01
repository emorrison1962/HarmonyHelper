using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHelper.IoC
{
    public static class Container
    {
        static public Microsoft.MinIoC.Container Instance { get;}
        static Container() 
        {
            Instance = new Microsoft.MinIoC.Container();
        }
    }
}
