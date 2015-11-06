using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace ContosoUniversity.Common
{
    public static class DelayExtension
    {
        public static void DelayCall(this object obj)
        {
            Thread.Sleep(15000);
        }
    }
}