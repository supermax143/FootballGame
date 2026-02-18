using System;
using System.Collections.Generic;
using Core.Domain.Services;
using Unity.Netcode;
using Zenject;

namespace Unity.Infrastructure.Network
{
    /// <summary>
    /// Observes NetworkBehaviour spawn/despawn events and dispatches them to subscribers.
    /// Implements generic subscription pattern for type-safe event handling.
    /// </summary>
    public class NetworkObjectSpawnObserver : INetworkObjectSpawnObserver, INetworkObjectSpawnHandler, IDisposable
    {
        
        private readonly Dictionary<Type, List<Delegate>> _spawnHandlers = new();
        private readonly Dictionary<Type, List<Delegate>> _despawnHandlers = new();

        public void Dispose()
        {
            _spawnHandlers.Clear();
            _despawnHandlers.Clear();
        }

        public void RaiseSpawnEvent(NetworkBehaviour behaviour)
        {
            DispatchSpawnEvent(behaviour);
        }

        public void RaiseDespawnEvent(NetworkBehaviour behaviour)
        {
            DispatchDespawnEvent(behaviour);
        }

        public IDisposable SubscribeSpawn<T>(Action<T> handler) where T : class
        {
            var type = typeof(T);
            
            if (!_spawnHandlers.TryGetValue(type, out var handlers))
            {
                handlers = new List<Delegate>();
                _spawnHandlers[type] = handlers;
            }
            
            handlers.Add(handler);
            
            return new Subscription(() => UnsubscribeSpawn(handler));
        }

        public IDisposable SubscribeDespawn<T>(Action<T> handler) where T : class
        {
            var type = typeof(T);
            
            if (!_despawnHandlers.TryGetValue(type, out var handlers))
            {
                handlers = new List<Delegate>();
                _despawnHandlers[type] = handlers;
            }
            
            handlers.Add(handler);
            
            return new Subscription(() => UnsubscribeDespawn(handler));
        }

        public void UnsubscribeSpawn<T>(Action<T> handler) where T : class
        {
            var type = typeof(T);
            
            if (_spawnHandlers.TryGetValue(type, out var handlers))
            {
                handlers.Remove(handler);
            }
        }

        public void UnsubscribeDespawn<T>(Action<T> handler) where T : class
        {
            var type = typeof(T);
            
            if (_despawnHandlers.TryGetValue(type, out var handlers))
            {
                handlers.Remove(handler);
            }
        }


        private void DispatchSpawnEvent(NetworkBehaviour behaviour)
        {
            var behaviourType = behaviour.GetType();
            
            foreach (var kvp in _spawnHandlers)
            {
                var subscribedType = kvp.Key;
                
                if (subscribedType.IsAssignableFrom(behaviourType))
                {
                    foreach (var handler in kvp.Value)
                    {
                        try
                        {
                            handler.DynamicInvoke(behaviour);
                        }
                        catch (Exception e)
                        {
                            UnityEngine.Debug.LogException(e);
                        }
                    }
                }
            }
        }

        private void DispatchDespawnEvent(NetworkBehaviour behaviour)
        {
            var behaviourType = behaviour.GetType();
            
            foreach (var kvp in _despawnHandlers)
            {
                var subscribedType = kvp.Key;
                
                if (subscribedType.IsAssignableFrom(behaviourType))
                {
                    foreach (var handler in kvp.Value)
                    {
                        try
                        {
                            handler.DynamicInvoke(behaviour);
                        }
                        catch (Exception e)
                        {
                            UnityEngine.Debug.LogException(e);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Internal disposable subscription class.
        /// </summary>
        private sealed class Subscription : IDisposable
        {
            private Action _unsubscribeAction;
            
            public Subscription(Action unsubscribeAction)
            {
                _unsubscribeAction = unsubscribeAction;
            }
            
            public void Dispose()
            {
                _unsubscribeAction?.Invoke();
                _unsubscribeAction = null;
            }
        }

    }
}

