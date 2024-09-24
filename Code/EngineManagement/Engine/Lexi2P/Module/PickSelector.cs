namespace PicKeyFinder.Code.EngineManagement.Engine.Lexi2P.Module
{
    public class PickSelector
    {
        Random random = new();
        
        // 媒体站
        private List<string> picList_1 = new List<string>()
        {
            "https://www.freeimg.cn/i/2024/09/24/66f22beb7a257.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22beb84f56.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22bebe73a5.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22bebd6bc0.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22bec5e358.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22bec56e26.webp"
        };
        // 种植
        private List<string> picList_2 = new List<string>()
        {
            "https://www.freeimg.cn/i/2024/09/24/66f22ce567bd1.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22ce25985e.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22ce25f969.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22ce25f252.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22ce2831bd.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22ce222911.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22ce258ece.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22ce2488ab.webp"
        };
        // 永生
        private List<string> picList_3 = new List<string>()
        {
            "https://www.freeimg.cn/i/2024/09/24/66f22d48ee08b.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22d4a54d75.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22d4a0f8a9.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22d48e7996.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22d4a50683.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22d49eb0fa.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22d4a67198.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22d4a28529.webp"
        };
        // 文化节
        private List<string> picList_4 = new List<string>()
        {
            "https://www.freeimg.cn/i/2024/09/24/66f22d7757281.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22d789e26b.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22d77bbddc.webp",
            "https://www.freeimg.cn/i/2024/09/24/66f22d786ab1b.webp"
        };
        // Error
        private List<string> picList_5 = new List<string>()
        {
            "https://www.freeimg.cn/i/2024/09/24/66f22dc21882d.webp",
        };
        
        public string PickPic(string word)
        {
            var returnPic = "";
            int index;

            switch (word)
            {
                case "媒体站":
                    index = random.Next(picList_1.Count);
                    returnPic = picList_1[index];
                    break;

                case "文化节":
                    index = random.Next(picList_2.Count);
                    returnPic = picList_2[index];
                    break;

                case "永生树":
                    index = random.Next(picList_3.Count);
                    returnPic = picList_3[index];
                    break;

                case "种植":
                    index = random.Next(picList_4.Count);
                    returnPic = picList_4[index];
                    break;

                default:
                    index = random.Next(picList_5.Count);
                    returnPic = picList_5[index];
                    break;
            }

            return returnPic;
        }
    }
}
