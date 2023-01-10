using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HarmonyHelper.Tests.Console
{
    internal class TestRunner
    {
        const string ASSEMBLY_PATH = @"..\..\..\HarmonyHelper.Tests\bin\Debug\HarmonyHelper.Tests.dll";

        public TestRunner()
        {
            this.Init();
        }

        void Init()
        {
        }

        Dictionary<MethodInfo, string> methods = new Dictionary<MethodInfo, string>();

        public class TaskContext
        { 
            public MethodInfo MethodInfo { get; set; }
            public Stopwatch Stopwatch { get; set; }
            public TaskContext(MethodInfo MethodInfo)
            {
                this.MethodInfo = MethodInfo;
                this.Stopwatch = Stopwatch.StartNew();
            }

            public void Stop()
            { 
                this.Stopwatch.Stop();
            }
        }

        internal void Run()
        {
#if false
D:\CODE\HarmonyHelper\HarmonyHelper\HarmonyHelper.Tests\bin\Debug\HarmonyHelper.Tests.dll
D:\CODE\HarmonyHelper\HarmonyHelper\HarmonyHelper.Tests.Console\bin\Debug\HarmonyHelper.Tests.Console.exe
#endif
            var tasks = new List<Task>();
            //var tests = this.GetTestMethods();
            var tests = this.GetTestMethod("ReHarmonizeTest");
            foreach (var mi in tests)
            {
                methods.Add(mi, mi.Name);
                System.Console.WriteLine($"+{mi.DeclaringType.Name}: {mi.Name}");
                try
                {
                    var testClass = Activator.CreateInstance(mi.DeclaringType);
                    var task = new TaskFactory().StartNew(
                        (state) => mi.Invoke(testClass, null), new TaskContext(mi));

                    task.ContinueWith((t) => this.Continue(t));
                    tasks.Add(task);
                }
                catch (Exception) { }
            }



            var tasksArr = tasks.ToArray();
            Task.WaitAll(tasksArr);
            new object();
        }

        List<MethodInfo> GetTestMethods()
        {
            var result = new List<MethodInfo>();
            var assembly = Assembly.LoadFrom(ASSEMBLY_PATH);

            var testClassTypes = assembly.GetTypes()
                .Where(x => null != x.GetCustomAttribute<TestClassAttribute>())
                .ToList();

            foreach (var tcType in testClassTypes)
            {
                var tc = Activator.CreateInstance(tcType);
                var tests = tcType.GetMethods()
                    .Where(x => null != x.GetCustomAttribute<TestMethodAttribute>()
                        && null == x.GetCustomAttribute<IgnoreAttribute>())
                    .ToList();
                result.AddRange(tests);
            }

#if false
            result.OrderBy(x => x.DeclaringType.Name)
                .ThenBy(x => x.Name)
                .ToList()
                .ForEach(x => Debug.WriteLine($"{x.DeclaringType.Name}: {x.Name}"));
#endif

            return result;
        }

        List<MethodInfo> GetTestMethod(string testName)
        { 
            var result = this.GetTestMethods()
                .Where(x => x.Name.ToLower() == testName.ToLower())
                .ToList();
            return result;
        }

        void Continue(Task<object> task) 
        {
            var ctx = task.AsyncState as TaskContext;
            ctx.Stop();
            methods.Remove(ctx.MethodInfo);
            System.Console.WriteLine($"-{ctx.MethodInfo.DeclaringType.Name}: {ctx.MethodInfo.Name}");

            new object();
        }
    }//class
}//ns