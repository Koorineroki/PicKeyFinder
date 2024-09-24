using PicKeyFinder.Code.EngineManagement;
using PicKeyFinder.Code.IO;

namespace PicKeyFinder.Code.Core
{
    public class TaskDistributor
    {
        private EnginePool enginePool;
        private bool debug;

        public TaskDistributor(int engineCount,bool debug)
        {
            this.debug = debug;
            enginePool = new EnginePool(engineCount);
        }

        public string AssignTask(string userDiscourse)
        {
            var engine = enginePool.GetEngine();
            if (engine != null)
            {
                var re = engine.Execute(userDiscourse, debug);
                enginePool.ReturnEngine(engine);
                return re;
            }

            Logger.LogSystemMessage(LogLevel.Error, "No available Engine to assign task.");
            return "No available Engine to use.";
        }
    }
}