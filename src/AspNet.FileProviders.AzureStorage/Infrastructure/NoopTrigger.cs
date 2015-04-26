using System;
using Microsoft.Framework.Expiration.Interfaces;

namespace AspNet.FileProviders.AzureStorage.Infrastructure
{
    internal class NoopTrigger : IExpirationTrigger
    {
        public static NoopTrigger Instance { get; } = new NoopTrigger();

        private NoopTrigger()
        {
        }

        public bool ActiveExpirationCallbacks
        {
            get { return false; }
        }

        public bool IsExpired
        {
            get { return false; }
        }

        public IDisposable RegisterExpirationCallback(Action<object> callback, object state)
        {
            throw new InvalidOperationException("Trigger does not support registering change notifications.");
        }
    }
}
