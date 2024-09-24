using JiebaNet.Analyser;
using PicKeyFinder.Code.EngineManagement.Engine.Lexi2P.Module;
using PicKeyFinder.Code.IO;

namespace PicKeyFinder.Code.EngineManagement.Engine.Lexi2P
{
    //Lexical to Picture Engine 
    public class Lexi2PEngine
    {
        private DiscourseProcess processEngine = new DiscourseProcess();
        private SynonymFilters synonymFilter = new SynonymFilters();
        private PickSelector pickSelector = new();
        
        public readonly int instanceIndex;
        private readonly string logPath;

        // Constructor, instanceIndex stores the Engine ID
        public Lexi2PEngine(int instanceIndex)
        {
            this.instanceIndex = instanceIndex;
            logPath = $"Lexi2PEngine{instanceIndex}.log";

            Logger.LogSystemMessage(LogLevel.Info, $"Lexi2P Engine ({instanceIndex}) is Create Now.");
        }

        // Start Execute
        public string Execute(string utterance, bool debug = false)
        {
            List<WordWeightPair> wordWeights;
            string returnText;

            //Log Message
            Logger.LogMessage($"【{DateTime.Now}】Lexi2P Engine ( {instanceIndex}) is being worked on this task.\n", logPath);
            Logger.LogMessage(utterance + "\n", logPath);

            // Run CoreLogic
            returnText = CoreLogic(utterance, debug);

            Logger.LogMessage("=================================================================", logPath);
            return returnText;
        }

        private string Logging(List<WordWeightPair> wordWeights, string pickWord)
        {
            var returnText = "";
            foreach (var word in wordWeights)
            {
                returnText += $"捕获关键字：{word.Word}，权重为{word.Weight}\n";
            }
            returnText += $"转换结果：{pickWord}";

            Logger.LogMessage(returnText, logPath);
            return returnText;
        }

        private string CoreLogic(string utterance, bool debug)
        {
            var returnText = "";

            // Pick Words
            var wordWeights = processEngine.GetKeyWordWeights(utterance);
            var pickWord = synonymFilter.PickWords(wordWeights);
            var imgMD = $"![image]({pickSelector.PickPic(pickWord)})\n";
            returnText += imgMD;

            if (debug)
            {
                // HAKC:
                returnText += Logging(wordWeights, pickWord);
            }
            else
            {
                Logging(wordWeights, pickWord);

                // HAKC:
                returnText = pickWord;
            }

            return returnText;
        }
    }
}
