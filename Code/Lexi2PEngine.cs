﻿using PicKeyFinder.Code.Modules;

namespace PicKeyFinder.Code
{
    //Lexical to Picture Engine 
    internal class Lexi2PEngine
    {
        private UtteranceProcess processEngine = new UtteranceProcess();
        private SynonymFilters synonymFilter = new SynonymFilters();

        // Start Execute
        public string Execute(string utterance)
        {
            var wordWeights = processEngine.GetKeyWordWeights(utterance, true);
            return synonymFilter.PickWords(wordWeights);
        }
    }
}
