using JiebaNet.Analyser;

namespace PicKeyFinder.Code.Modules
{
    internal class SynonymFilter
    {
        Dictionary<string, string> synonymDictionary = new Dictionary<string, string>
        {
            { "火星", "火星" },
            { "星球", "火星" },
            { "行星", "火星" },
            { "表面", "火星" },
            { "外星", "火星" },
            { "尘暴", "火星" },
            { "沙尘暴", "火星" },
            { "登陆", "火星" },
            /*
            { "宇宙", "宇宙" },
            { "星系", "宇宙" },
            { "空间", "宇宙" },
            { "时间", "宇宙" },
            { "星宇", "宇宙" },
            { "星域", "宇宙" },
            { "星际", "宇宙" },
            { "星云", "宇宙" },
            { "银河系", "宇宙" },
            { "天体", "宇宙" },

            { "火箭", "火箭" },
            { "星舰", "火箭" },
            { "光帆", "火箭" },

            { "船舱", "空间站内" },
            { "船仓", "空间站内" },

            { "基地", "基地" },
            { "火星基地", "基地" },
            { "船厂", "基地" },

            { "计算机", "计算机" },
            { "屏幕", "计算机" },
            { "人工智能", "计算机" },
            { "编码", "计算机" },

            { "探测器", "探测器" },
            { "信号", "探测器" },
            { "光年", "探测器" },

            { "能量", "能源" },
            { "电力", "能源" },
            { "太阳能", "能源" },
            { "光伏", "能源" },
            { "核能", "能源" },
            { "核电", "能源" },
            { "原子能", "能源" },
            { "发电", "能源" },
            { "储能", "能源" },
            { "氢能", "能源" },
            { "氢气", "能源" },

            { "舰长", "人" },
            { "船长", "人" },
            { "人类", "人" },
            { "船员", "人" },
            { "科学家", "人" },

            { "机器人", "机器人" },

            { "机器", "设备" },
            { "设备", "设备" },
            */
        };

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
                    filteredWords.Add("Error");
                    Console.WriteLine($"{pair.Word}\t未匹配成功");
                }
            }
            return filteredWords;
        }

        public string PickWords(List<WordWeightPair> wordWeights)
        {
            var filteredWords = Filter(wordWeights);
            if (filteredWords.Count ==0)
            {
                return "No word can Pick";
            }

            // return first word
            return filteredWords[0];
        }
    }
}
