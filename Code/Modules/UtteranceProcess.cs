using JiebaNet.Analyser;
using System.Diagnostics;

namespace PicKeyFinder.Code.Modules
{
    internal class UtteranceProcess
    {
        // Add extractor
        private TfidfExtractor extractor = new TfidfExtractor();
        // Allowed parts of speech (nouns only)
        private IEnumerable<string> allowedPos = new List<string> { "n" };

        // Private method: 
        // Extract nouns and label them with weights
        private List<WordWeightPair> GetKeyWordWeights(string inputText)
        {
            return extractor.ExtractTagsWithWeight(inputText, 5, allowedPos).ToList();
        }
        // Public method: 
        // Added debug mode based on the original method
        public List<WordWeightPair> GetKeyWordWeights(string inputText, bool debug = false)
        {
            List<WordWeightPair> wordWeights;
            if (debug)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Reset();
                stopwatch.Start();
                wordWeights = GetKeyWordWeights(inputText);
                stopwatch.Stop();

                DebugTools.OutputMessage(inputText.Length, stopwatch.ElapsedMilliseconds, wordWeights);
            }
            else
            {
                wordWeights = GetKeyWordWeights(inputText);
            }
            return wordWeights;
        }
    }
}
