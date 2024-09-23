using PicKeyFinder.Code.EngineManagement;
using PicKeyFinder.Code.IO;

namespace PicKeyFinder.Code.Core
{
    internal class TaskDistributor
    {
        private EnginePool enginePool;

        public TaskDistributor(int engineCount)
        {
            enginePool = new EnginePool(engineCount);
        }

        public string AssignTask(string userDiscourse)
        {
            var engine = enginePool.GetEngine();
            if (engine != null)
            {
                var re = engine.Execute(userDiscourse, true);
                enginePool.ReturnEngine(engine);
                return re;
            }
            Logger.LogSystemMessage(LogLevel.Error, "No available Engine to assign task.");
            
            return "No available Engine to use.";
        }
    }
}