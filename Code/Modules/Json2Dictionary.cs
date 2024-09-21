using System.Text.Json;

namespace PicKeyFinder.Code.Modules
{
    internal class Json2Dictionary
    {
        // Load Dictionary form Json
        public Dictionary<string, string> LoadDictionary(string filePath)
        {
            var dict = new Dictionary<string, string>();
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);

                // 反序列化为 Dictionary<string, List<string>> 格式
                var tempDictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonContent) ?? new Dictionary<string, List<string>>();

                // 遍历每个固定词语，将其同义词添加到 synonymDictionary
                foreach (var entry in tempDictionary)
                {
                    string fixedWord = entry.Key;
                    List<string> synonyms = entry.Value;

                    foreach (var synonym in synonyms)
                    {
                        dict[synonym] = fixedWord;
                    }
                }
            }
            else
            {
                Console.WriteLine("Error: File not found.");
                dict = new Dictionary<string, string>();  // 如果文件不存在，初始化为空字典
            }

            return dict;
        }
    }
}
