namespace PicKeyFinder.Code.EngineManagement.Engine.Lexi2P.Module
{
    public class PickSelector
    {
        Random random = new();

        public string PickPic(string word)
        {
            var returnPic = "";

            switch (word)
            {
                case "媒体站":
                    break;

                case "文化节":
                    break;

                case "永生树":
                    break;

                case "种植":
                    break;

                default:
                    returnPic = "Error";
                    break;
            }

            return returnPic;
        }
    }
}
