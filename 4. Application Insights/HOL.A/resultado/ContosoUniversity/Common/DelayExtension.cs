using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;

namespace ContosoUniversity.Common
{
    public static class DelayExtension
    {
        public static void DelayCall(this object obj)
        {
            Trace.TraceWarning("Esto es lo que esta haciendo lenta la aplicación!");
            Thread.Sleep(15000);
        }
    }
}