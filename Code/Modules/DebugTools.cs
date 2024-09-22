using JiebaNet.Analyser;
using System.Diagnostics;

namespace PicKeyFinder.Code.Modules
{
    internal static class DebugTools
    {
        public enum Level
        {

        }

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


        // NOTE:
        // This code is used for testing during development
        // And can **ONLY** be used to output "分词后的结果"
        // HACK:
        // Since WriteLine is not thread-safe, this method cannot be used on multiple threads.
        public static void OutputMessage(int textLength, long useTime, List<WordWeightPair> wordWeights)
        {
            Console.WriteLine($"处理文字量：{textLength}");
            Console.WriteLine($"分词所用时间: {useTime} 毫秒");
            Console.WriteLine("提取的关键词及其权重并排序：");
            foreach (var word in wordWeights)
            {
                Console.WriteLine($"【词语】：{word.Word}，\t【权重】：{word.Weight}");
            }
        }
    }
}
