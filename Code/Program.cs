using PicKeyFinder.Code.Modules;
using System.Diagnostics;

namespace PicKeyFinder.Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // JiebaNet.Segmenter.ConfigManager.ConfigFileBaseDir = @"F:\Code\C#\PicKeyFinder\Resources";
            while (true)
            {
                Console.WriteLine("请输入对话内容。");
                string userDiscourse = Console.ReadLine() ?? string.Empty;

                // HACK: 临时方案，在未来需要改用对象池进行对象的复用。
                Lexi2PEngine engine = new Lexi2PEngine();
                var wl = engine.Execute(userDiscourse);

                Console.WriteLine($"选取的关键词：{wl}");
                // Context Segmentation
                Console.WriteLine("====================================================");
                Console.WriteLine();
            }
        }
    }
}
