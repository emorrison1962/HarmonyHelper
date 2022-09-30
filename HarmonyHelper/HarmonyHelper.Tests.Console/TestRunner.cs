using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HarmonyHelper.Tests.Console
{
    internal class TestRunner
    {
        public TestRunner()
        {
            this.Init();
        }

        void Init()
        {
#if false
D:\CODE\HarmonyHelper\HarmonyHelper\HarmonyHelper.Tests\bin\Debug\HarmonyHelper.Tests.dll
D:\CODE\HarmonyHelper\HarmonyHelper\HarmonyHelper.Tests.Console\bin\Debug\HarmonyHelper.Tests.Console.exe
#endif
            const string ASSEMBLY_PATH = @"..\..\..\HarmonyHelper.Tests\bin\Debug\HarmonyHelper.Tests.dll";
            Debug.WriteLine(Assembly.GetExecutingAssembly().Location);
            if (File.Exists(ASSEMBLY_PATH))
            {
                new object();
            }
            else
            { 
                throw new FileNotFoundException(ASSEMBLY_PATH);
            }
            var assembly = Assembly.LoadFrom(ASSEMBLY_PATH);

            var testClassTypes = assembly.GetTypes()
                .Where(x => null != x.GetCustomAttribute<TestClassAttribute>())
                .ToList();

            foreach (var tcType in testClassTypes)
            {
                var tc = Activator.CreateInstance(tcType);
                var tests = tcType.GetMethods()
                    .Where(x => null != x.GetCustomAttribute<TestMethodAttribute>());

                foreach (var mi in tests)
                {
                    Debug.WriteLine($"{tcType.Name}: {mi.Name}");
                    try
                    {
                        mi.Invoke(tc, null);
                    }
                    catch (Exception) { }                
                }
                new object();
            }
            new object();
        }

        internal void Run()
        {
            throw new NotImplementedException();
        }
    }
}