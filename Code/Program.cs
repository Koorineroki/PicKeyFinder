using System.Collections.Concurrent;
using PicKeyFinder.Code.Modules;
using System.Diagnostics;

namespace PicKeyFinder.Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.LogSystemMessage(LogLevel.None,"====================================================");
            Logger.LogSystemMessage(LogLevel.None,"System Start");
            
            var enginePool = new EnginePool(20);
            while (true)
            {
                Console.WriteLine("请输入对话内容。");
                string userDiscourse = Console.ReadLine() ?? string.Empty;
                
                string wl;
                var engine = enginePool.GetEngine();
                if (engine != null)
                {
                    wl = engine.Execute(userDiscourse);
                    enginePool.ReturnEngine(engine);
                }
                else
                {
                    wl = "No Engine can use.";
                }
                
                Console.WriteLine($"选取的关键词：{wl}");
                // Context Segmentation
                Console.WriteLine("====================================================");
                Console.WriteLine();
            }
        }
    }
}
