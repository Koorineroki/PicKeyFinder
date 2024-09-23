using PicKeyFinder.Code.IO;

namespace PicKeyFinder.Code.EngineManagement.Engine.Lexi2P
{
    //Lexical to Picture Engine 
    public class Lexi2PEngine
    {
        private DiscourseProcess processEngine = new DiscourseProcess();
        private SynonymFilters synonymFilter = new SynonymFilters();
        public readonly int instanceIndex;

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
        public string Execute(string utterance)
        {
            var wordWeights = processEngine.GetKeyWordWeights(utterance, true);
            return synonymFilter.PickWords(wordWeights);
        }
    }
}
