using JiebaNet.Analyser;

namespace PicKeyFinder.Code.Modules
{
    internal class SynonymFilters
    {
        Dictionary<string, string> synonymDictionary;


        public SynonymFilters()
        {
            // Load synonymDictionary form Json
            synonymDictionary = new Json2Dictionary().LoadDictionary("SynonymDict\\synonyms.json");
        }

        // Filter word(s) according to synonymDictionary 
        private List<string> Filter(List<WordWeightPair> wordWeights)
        {
            var filteredWords = new List<string>();
            foreach (var pair in wordWeights)
            {
                if (synonymDictionary.TryGetValue(pair.Word, out var filteredWord))
                {
                    filteredWords.Add(filteredWord);
                    Console.WriteLine($"{pair.Word}\t被转化成了\t{filteredWord}");
                }
                else
                {
                    Console.WriteLine($"{pair.Word}\t未匹配成功");
                }
            }
            return filteredWords;
        }

        // Choose an appropriate word from the text.
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
