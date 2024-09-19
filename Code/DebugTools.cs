using System.Diagnostics;

namespace PicKeyFinder.Code
{
    internal static class DebugTools
    {
        // Run the method And Timing
        // No parameter And No return
        public static void RunWithTimer(Action action, out long executionTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            action.Invoke();            // Invoke
            stopwatch.Stop();
            executionTime = stopwatch.ElapsedMilliseconds;
        }
        // No parameter And Has return (Func<TResult>)
        public static TResult RunWithTimer<TResult>(Func<TResult> func, out long executionTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            TResult re = func();        // Invoke
            stopwatch.Stop();
            executionTime = stopwatch.ElapsedMilliseconds;
            return re;
        }
        // Has parameter And Has return (Func<T, TResult>)
        public static TResult RunWithTimer<T, TResult>(Func<T, TResult> func, T param, out long executionTime)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            TResult re = func(param);   // Invoke
            stopwatch.Stop();
            executionTime = stopwatch.ElapsedMilliseconds;
            return re;
        }
    }
}
