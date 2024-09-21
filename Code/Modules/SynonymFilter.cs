using JiebaNet.Analyser;

namespace PicKeyFinder.Code.Modules
{
    internal class SynonymFilter
    {

        public string PickWords(List<WordWeightPair> wordWeights)
        {
            if (wordWeights.Count != 0)
            {
                return wordWeights[0].Word;
            }
            else
            {
                return "Error：No word can pick";
            }
        }
    }
}
