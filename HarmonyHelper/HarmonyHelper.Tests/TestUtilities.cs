using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Eric.Morrison
{
    public static class TestUtilities
    {
        public class DisableAssertionDialogs : IDisposable
        {
            public DisableAssertionDialogs()
            {
                this.Disable();
            }
            void Disable()
            {
                DefaultTraceListener dtl = Trace.Listeners.OfType<DefaultTraceListener>().FirstOrDefault();
                if (null != dtl)
                    dtl.AssertUiEnabled = false;
            }
            public void Enable()
            {
                DefaultTraceListener dtl = Trace.Listeners.OfType<DefaultTraceListener>().FirstOrDefault();
                if (null != dtl)
                    dtl.AssertUiEnabled = true;
            }

            private bool disposedValue;

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        this.Enable();
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                    // TODO: set large fields to null
                    disposedValue = true;
                }
            }

            public void Dispose()
            {
                // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }
        }//class
    }//class
}//ns
