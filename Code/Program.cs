using PicKeyFinder.Code.Core;
using PicKeyFinder.Code.EngineManagement;
using PicKeyFinder.Code.IO;

namespace PicKeyFinder.Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.LogSystemMessage(LogLevel.None,"====================================================");
            Logger.LogSystemMessage(LogLevel.None,"System Start");

            var taskDistributor = new TaskDistributor(5);

            while (true)
            {
                Console.WriteLine("请输入对话内容。");
                string userDiscourse = Console.ReadLine() ?? string.Empty;
                
                string wl = taskDistributor.AssignTask(userDiscourse);


                Console.WriteLine($"选取的关键词：{wl}");
                // Context Segmentation
                Console.WriteLine("====================================================");
                Console.WriteLine();
            }
        }
    }
}
