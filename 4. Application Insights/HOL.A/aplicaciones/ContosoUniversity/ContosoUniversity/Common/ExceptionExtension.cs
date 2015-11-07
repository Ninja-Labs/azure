using System;
using System.Diagnostics;

namespace ContosoUniversity.Common
{
    public static class ExceptionExtension
    {
        public static void Ups(this object obj)
        {
            var ex =
                new ThisCouldBeAProductionException(
                    "Ojo! esto puede ser una excepción no controlada en su código de producción");
            Trace.TraceError("Esta es la excepción que va a lanzar",ex.ToString());
            throw ex;
        }
    }

    public class ThisCouldBeAProductionException : Exception
    {
        public ThisCouldBeAProductionException(string message)
            :base(message)
        { }
    }
}