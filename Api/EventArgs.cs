using System;

namespace Memenim.Core.Api
{
    public class ConnectionStateChangedEventArgs : EventArgs
    {
        public ConnectionStateType OldState { get; }
        public ConnectionStateType NewState { get; }

        public ConnectionStateChangedEventArgs(ConnectionStateType oldState,
            ConnectionStateType newState)
        {
            OldState = oldState;
            NewState = newState;
        }
    }
}
