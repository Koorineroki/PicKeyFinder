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
                var userDiscourse = Console.ReadLine() ?? string.Empty;

                // HACK: 临时方案，在未来需要改用对象池进行对象的复用。
                long aTime;
                var wordWeights = DebugTools.RunWithTimer(new TextProcess().GetKeywords, userDiscourse, out aTime);

                // 停止计时
                Console.WriteLine($"处理文字量：{userDiscourse.Length}");
                Console.WriteLine($"执行时间: {aTime} 毫秒");

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
