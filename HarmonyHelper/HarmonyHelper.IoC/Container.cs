using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.MinIoC;

namespace HarmonyHelper.IoC
{
    public static class Container
    {
        static Microsoft.MinIoC.Container Instance { get; set; }
        static Container()
        {
            Instance = new Microsoft.MinIoC.Container();
            Bootstrap();
        }

        static public void Bootstrap()
        {
            //Instance.Register<IFoo>(typeof(Foo));
            //Instance.Register<IBar>(() => new Bar());
            //Instance.Register<IBaz>(typeof(Baz)).AsSingleton();
        }

        static public void Register<T>(object instance)
        {
            Func<object> factory = () => instance;
            Instance.Register(typeof(T), factory).AsSingleton();
        }
        static public T Resolve<T>()
        {
            var result = Instance.Resolve<T>();
            return result;
        }

    }//class
}
