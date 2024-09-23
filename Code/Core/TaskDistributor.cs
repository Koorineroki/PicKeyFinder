using PicKeyFinder.Code.EngineManagement;

namespace PicKeyFinder.Code.Core
{
    internal class TaskDistributor
    {
        private EnginePool enginePool;

        public TaskDistributor(int engineCount)
        {
            enginePool = new EnginePool(engineCount);
        }

        public string StartTask(string userDiscourse)
        {
            var engine = enginePool.GetEngine();
            if (engine != null)
            {
                return engine.Execute(userDiscourse);
            }
            return "No Engine can use";
        }
    }
}