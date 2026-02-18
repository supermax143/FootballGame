using System;

namespace Core.Domain.Services
{
   
    public interface INetworkObjectSpawnObserver
    {
        IDisposable SubscribeSpawn<T>(Action<T> handler) where T : class;
        IDisposable SubscribeDespawn<T>(Action<T> handler) where T : class;
        void UnsubscribeSpawn<T>(Action<T> handler) where T : class;
        void UnsubscribeDespawn<T>(Action<T> handler) where T : class;
    }
}

