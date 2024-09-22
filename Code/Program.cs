﻿using PicKeyFinder.Code.Modules;
using System.Diagnostics;

namespace PicKeyFinder.Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lexi2PEngine engine = new Lexi2PEngine();

            //JiebaNet.Segmenter.ConfigManager.ConfigFileBaseDir = @"\root\test2\Resources";
            var logger = new Logger();
            while (true)
            {
                logger.LogSystemMessage(LogLevel.Info, "新用户输入");

                Console.WriteLine("请输入对话内容。");
                string userDiscourse = Console.ReadLine() ?? string.Empty;

                // HACK: 临时方案，在未来需要改用对象池进行对象的复用。
                var wl = engine.Execute(userDiscourse);

                Console.WriteLine($"选取的关键词：{wl}");
                // Context Segmentation
                Console.WriteLine("====================================================");
                Console.WriteLine();
            }
        }
    }
}
