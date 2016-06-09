using System;

namespace Sample.Application.Console.Samples
{
    public static class StaticClassSample //no instance for this class, sealed class, no inheritance
    {
        public static string StaticField;

        public static void StaticMethod()
        {
        }

        public static event EventHandler StaticEvent;
    }
}
