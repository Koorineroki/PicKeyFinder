using JiebaNet.Analyser;
using PicKeyFinder.Code.IO;

namespace PicKeyFinder.Code.EngineManagement.Engine.Lexi2P.Module
{
    internal class SynonymFilters
    {
        Dictionary<string, string> synonymDictionary;


        public SynonymFilters()
        {
            // Load synonymDictionary form Json
            string path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, "SynonymDict", "synonyms.json");
            synonymDictionary = new Json2Dictionary().LoadDictionary(path);
        }

        // Filter word(s) according to synonymDictionary 
        // Debug Mode
        private List<string> Filter(List<WordWeightPair> wordWeights,string logPath)
        {
            var filteredWords = new List<string>();
            var debugMessage = "";
            foreach (var pair in wordWeights)
            {
                if (synonymDictionary.TryGetValue(pair.Word, out var filteredWord))
                {
                    filteredWords.Add(filteredWord);
                    debugMessage += $"{pair.Word}\t被转化成了\t{filteredWord}。\n";
                }
                else
                {
                    debugMessage += $"{pair.Word}\t未匹配成功。\n";
                    Console.WriteLine();
                }
            }
            Logger.LogMessage(debugMessage, logPath);

            return filteredWords;
        }
        // Normal
        private List<string> Filter(List<WordWeightPair> wordWeights)
        {
            var filteredWords = new List<string>();
            foreach (var pair in wordWeights)
            {
                if (synonymDictionary.TryGetValue(pair.Word, out var filteredWord))
                {
                    filteredWords.Add(filteredWord);
                }
            }
            return filteredWords;
        }

        // Choose an appropriate word from the text.
        public string PickWords(List<WordWeightPair> wordWeights,string logPath)
        {
            var filteredWords = Filter(wordWeights, logPath);
            if (filteredWords.Count == 0)
            {
                return "No word can Pick";
            }

            // return first word
            return filteredWords[0];
        }
        public string PickWords(List<WordWeightPair> wordWeights)
        {
            var filteredWords = Filter(wordWeights);
            if (filteredWords.Count == 0)
            {
                return "No word can Pick";
            }

            // return first word
            return filteredWords[0];
        }


    }
}
