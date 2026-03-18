using System;
using System.Threading;

namespace FIASUpdate
{
    /// <summary>
    /// Захватывает контекст синхронизации текущего потока и вызывает события в нём.
    /// </summary>
    public class SyncEvent
    {
        private readonly SynchronizationContext Context;
        private readonly object Sender;

        public SyncEvent(object sender)
        {
            Sender = sender;
            Context = SynchronizationContext.Current;
        }

        /// <summary>
        /// Отправить асинхронное сообщение в контекст синхронизации.
        /// </summary>
        public void PostEvent<T>(EventHandler<T> handler, T args) where T : EventArgs => Context.Post(GetCallback(handler), args);

        /// <summary>
        /// Отправить синхронное сообщение в контекст синхронизации.
        /// </summary>
        public void SendEvent<T>(EventHandler<T> handler, T args) where T : EventArgs => Context.Send(GetCallback(handler), args);

        private SendOrPostCallback GetCallback<T>(EventHandler<T> handler)
        {
            return (state) =>
            {
                T E = (T)state;
                handler?.Invoke(Sender, E);
            };
        }
    }
}