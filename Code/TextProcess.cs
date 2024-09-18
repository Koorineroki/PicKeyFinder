﻿using JiebaNet.Analyser;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PicKeyFinder.Code
{
    internal class TextProcess
    {
        // Output dictionary of keywords and their weights.
        Dictionary<string, double> wordWeights = new Dictionary<string, double>();
        // Allowed parts of speech (nouns only)
        IEnumerable<string> allowedPos = new List<string> { "n" };

        // 提取名词并标记权重
        public Dictionary<string, double> GetKeywords(string inputText)
        {
            Reset();
            var extractor = new TfidfExtractor();
            var keywords = extractor.ExtractTagsWithWeight(inputText, 5, allowedPos);

            foreach (var keyword in keywords) wordWeights.Add(keyword.Word, keyword.Weight);
            return wordWeights;
        }

        void Reset()
        {
            wordWeights.Clear();
        }
    }
}
