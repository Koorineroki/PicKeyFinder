using PicKeyFinder.Code.EngineManagement.Engine.Lexi2P.Module;
using PicKeyFinder.Code.IO;

namespace PicKeyFinder.Code.EngineManagement.Engine.Lexi2P
{
    //Lexical to Picture Engine 
    public class Lexi2PEngine
    {
        private DiscourseProcess processEngine = new DiscourseProcess();
        private SynonymFilters synonymFilter = new SynonymFilters();
        public readonly int instanceIndex;

        // Constructor, instanceIndex stores the Engine ID
        public Lexi2PEngine(int instanceIndex)
        {
            this.instanceIndex = instanceIndex;
            Logger.LogSystemMessage(LogLevel.Info, $"Lexi2P Engine ({instanceIndex}) is Create Now.");
        }
        public Lexi2PEngine()
        {
            instanceIndex = -1;
            Logger.LogSystemMessage(LogLevel.Info, "Lexi2P Engine Create.");
        }

        // Start Execute
        public string Execute(string utterance, bool debug = false)
        {
            string returnText;
            if (debug)
            {
                var logPath = $"Lexi2PEngine{instanceIndex}.log";

                Logger.LogMessage($"Lexi2P Engine ({this.instanceIndex}) Working on this task.\n", logPath);
                Logger.LogMessage(utterance + "\n", logPath);
                var wordWeights = processEngine.GetKeyWordWeights(utterance, logPath);
                returnText = synonymFilter.PickWords(wordWeights, logPath);
                Logger.LogMessage("=================================================================", logPath);
            }
            else
            {
                var wordWeights = processEngine.GetKeyWordWeights(utterance);
                returnText = synonymFilter.PickWords(wordWeights);
            }

            return returnText;
        }
    }
}
