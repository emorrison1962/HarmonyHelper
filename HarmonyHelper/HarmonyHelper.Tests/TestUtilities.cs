using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Eric.Morrison
{
    public static class TestUtilities
    {
        static public void DisableAssertionDialogs()
        {
            DefaultTraceListener dtl = Trace.Listeners.OfType<DefaultTraceListener>().FirstOrDefault();
            if (null != dtl)
                dtl.AssertUiEnabled = false;
        }
    }
}
