using System.Collections.Concurrent;
using PicKeyFinder.Code.EngineManagement.Engine.Lexi2P;
using PicKeyFinder.Code.IO;

namespace PicKeyFinder.Code.EngineManagement;

public class EnginePool
{
    private readonly ConcurrentQueue<Lexi2PEngine> enginePool;

    public EnginePool(int count)
    {
        enginePool = new();
        for (int i = 0; i < count; i++)
        {
            var engine = new Lexi2PEngine(i);
            enginePool.Enqueue(engine);
            Logger.LogSystemMessage(LogLevel.Info, $"Lexi2P Engine ({i}) has been added to the engine pool.");
        }
        Logger.LogSystemMessage(LogLevel.Info, "EnginePool Initialization completed=================================================");
    }


    public Lexi2PEngine? GetEngine()
    {
        if (enginePool.TryDequeue(out var engine))
        {
            Logger.LogSystemMessage(LogLevel.Info, $"Lexi2P Engine ({engine.instanceIndex}) is now used.");
            return engine;
        }
        return null;
    }

    public void ReturnEngine(Lexi2PEngine engine)
    {
        Logger.LogSystemMessage(LogLevel.Info, $"Lexi2P Engine ({engine.instanceIndex})is now returned.");
        enginePool.Enqueue(engine);
    }
}