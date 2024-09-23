using System.Collections.Concurrent;

namespace PicKeyFinder.Code.Modules;

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
            Logger.LogSystemMessage(LogLevel.Info,$"The Lexi2P Engine {i} has been added to the engine pool.");
        }
        Logger.LogSystemMessage(LogLevel.Info,"EnginePool Initialization completed=================================================");
    }

    public Lexi2PEngine GetEngine()
    {
        if (enginePool.TryDequeue(out var engine))
        {
            Logger.LogSystemMessage(LogLevel.Info,$"The Lexi2P Engine {engine.instanceIndex} has in use now.");
            return engine;
        }
        return null;
    }

    public void ReturnEngine(Lexi2PEngine engine)
    {
        Logger.LogSystemMessage(LogLevel.Info,$"The Lexi2P Engine {engine.instanceIndex} has return to engine pool now.");
        enginePool.Enqueue(engine);
    }
}