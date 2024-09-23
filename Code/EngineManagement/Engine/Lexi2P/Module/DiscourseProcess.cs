using JiebaNet.Analyser;
using PicKeyFinder.Code.IO;
using System.Diagnostics;

namespace PicKeyFinder.Code.EngineManagement.Engine.Lexi2P.Module
{
    internal class DiscourseProcess
    {
        // Add extractor
        private TfidfExtractor extractor = new TfidfExtractor();
        // Allowed parts of speech (nouns only)
        private IEnumerable<string> allowedPos = new List<string> { "n" };

        // Private method: 
        // Extract nouns and label them with weights
        private List<WordWeightPair> _GetKeyWordWeights(string inputText)
        {
            return extractor.ExtractTagsWithWeight(inputText, 5, allowedPos).ToList();
        }

        // Public method: 
        // Added debug mode based on the original method
        public List<WordWeightPair> GetKeyWordWeights(string inputText, string logPath)
        {
            List<WordWeightPair> wordWeights;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
            wordWeights = _GetKeyWordWeights(inputText);
            stopwatch.Stop();

            // Log Debug Message
            string debugMessage = "";
            debugMessage += $"处理文字量：{inputText.Length}。\n";
            debugMessage += $"分词所用时间: {stopwatch.ElapsedMilliseconds} 毫秒。\n";
            foreach (var word in wordWeights)
            {
                debugMessage += $"【词语】：{word.Word}，\t【权重】：{word.Weight}。\n";
            }
            Logger.LogMessage(debugMessage, logPath);

            return wordWeights;
        }
        // No debug
        public List<WordWeightPair> GetKeyWordWeights(string inputText)
        {
            var wordWeights = _GetKeyWordWeights(inputText);
            return wordWeights;
        }
    }
}
