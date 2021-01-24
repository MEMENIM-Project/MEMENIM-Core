using System;

namespace Memenim.Core.Api
{
    public class ConnectionStateChangedEventArgs : EventArgs
    {
        public ConnectionState NewState { get; }

        public ConnectionStateChangedEventArgs(ConnectionState newState)
        {
            NewState = newState;
        }
    }
}
