using System;

namespace ContosoUniversity.Common
{
    public static class ExceptionExtension
    {
        public static void Ups(this object obj)
        {
            throw new ThisCouldBeAProductionException("Ojo! esto puede ser una excepción no controlada en su código de producción");
        }
    }

    public class ThisCouldBeAProductionException : Exception
    {
        public ThisCouldBeAProductionException(string message)
            :base(message)
        { }
    }
}