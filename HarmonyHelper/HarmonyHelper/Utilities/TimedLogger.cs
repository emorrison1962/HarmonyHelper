using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonyHelper.Utilities
{
    public class TimedLogger : IDisposable
    {
        private bool disposedValue;

        string MethodName { get; set; }
        Stopwatch Stopwatch { get; set; }

        public TimedLogger(string methodName)
        {
            this.MethodName = methodName;
            //Debug.WriteLine($"+{this.MethodName}");
            this.Stopwatch = Stopwatch.StartNew();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.Stopwatch.Stop();
                    Debug.WriteLine($"-{this.MethodName} took: {this.Stopwatch.ElapsedMilliseconds}, {this.Stopwatch.ElapsedTicks}");

                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~TimedLogger()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
