using PicKeyFinder.Code.Modules;

namespace PicKeyFinder.Code
{
    //Lexical to Picture Engine 
    public class Lexi2PEngine
    {
        private UtteranceProcess processEngine = new UtteranceProcess();
        private SynonymFilters synonymFilter = new SynonymFilters();
        public readonly int instanceIndex;
        
        public Lexi2PEngine(int instanceIndex)
        {
            this.instanceIndex = instanceIndex;
            Logger.LogSystemMessage(LogLevel.Info,$"Lexi2P Engine (No.{instanceIndex}) is Creat Now.");
        }

        public Lexi2PEngine()
        {
            this.instanceIndex = -1;
            Logger.LogSystemMessage(LogLevel.Info,"Lexi2P Engine is Creat Now.");
        }

        // Start Execute
        public string Execute(string utterance)
        {
            var wordWeights = processEngine.GetKeyWordWeights(utterance, true);
            return synonymFilter.PickWords(wordWeights);
        }
    }
}
