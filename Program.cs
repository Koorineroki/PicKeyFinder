using JiebaNet.Analyser;
using JiebaNet.Segmenter;
using JiebaNet.Segmenter.PosSeg;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PicKeyFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // JiebaNet.Segmenter.ConfigManager.ConfigFileBaseDir = @"F:\Code\C#\PicKeyFinder\Resources";
            Stopwatch stopwatch = new Stopwatch();

            while (true)
            {
                Console.WriteLine("请输入对话内容。");
                var userDiscourse = Console.ReadLine() ?? string.Empty;

                // 处理前重置并启动计时器
                stopwatch.Reset();
                stopwatch.Start();

                // HACK: 临时方案，在未来需要改用对象池进行对象的复用。
                var wordWeights = new TextProcess().GetKeywords(userDiscourse);

                // 停止计时
                stopwatch.Stop();
                Console.WriteLine($"处理文字量：{userDiscourse.Length}");
                Console.WriteLine($"执行时间: {stopwatch.ElapsedMilliseconds} 毫秒");

                // OutPut
                Console.WriteLine("提取的关键词及其权重并排序：");
                foreach (var word in wordWeights)
                {
                    Console.WriteLine($"【词语】：{word.Key}，\t【权重】：{word.Value}");
                }

                // CallBack
                Console.WriteLine("====================================================");
                Console.WriteLine();
            }
        }
    }
}
