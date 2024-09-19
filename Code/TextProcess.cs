using JiebaNet.Analyser;

namespace PicKeyFinder.Code
{
    internal class TextProcess
    {
        // The dictionary of keywords and their weights.
        Dictionary<string, double> wordWeights = new Dictionary<string, double>();
        // Allowed parts of speech (nouns only)
        IEnumerable<string> allowedPos = new List<string> { "n" };

        // Reset dictionary.
        void Reset()
        {
            wordWeights.Clear();
        }

        // Private method: 
        // Extract nouns and label them with weights
        private Dictionary<string, double> GetKeywords(string inputText)
        {
            Reset();
            var extractor = new TfidfExtractor();
            var keywords = extractor.ExtractTagsWithWeight(inputText, 5, allowedPos);

            foreach (var keyword in keywords) wordWeights.Add(keyword.Word, keyword.Weight);
            return wordWeights;
        }

        // Public method: 
        // Added debug mode based on the original method
        public Dictionary<string, double> GetKeywords(string inputText, bool debug = false)
        {
            if (debug)
            {
                long aTime;
                var wordWeights = DebugTools.RunWithTimer(GetKeywords, inputText, out aTime);
                DebugTools.OutputMessage(inputText.Length, aTime, wordWeights);
            }
            else
            {
                var wordWeights = GetKeywords(inputText);
            }
            return wordWeights;
        }
    }
}
