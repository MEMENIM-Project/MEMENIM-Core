using System;

namespace Memenim.Core.Api
{
    public class CoreInformationEventArgs : EventArgs
    {
        public Exception SourceException { get; }
        public string Message { get; }

        public CoreInformationEventArgs(string message)
            : this(null, message)
        {

        }
        public CoreInformationEventArgs(Exception sourceException,
            string message)
        {
            SourceException = sourceException;
            Message = message;
        }
    }

    public class CoreWarningEventArgs : EventArgs
    {
        public Exception SourceException { get; }
        public string Message { get; }

        public CoreWarningEventArgs(string message)
            : this(null, message)
        {

        }
        public CoreWarningEventArgs(Exception sourceException,
            string message)
        {
            SourceException = sourceException;
            Message = message;
        }
    }

    public class CoreErrorEventArgs : EventArgs
    {
        public Exception SourceException { get; }
        public string Message { get; }
        public string Stacktrace { get; }

        public CoreErrorEventArgs(string message, string stacktrace)
            : this(null, message, stacktrace)
        {

        }
        public CoreErrorEventArgs(Exception sourceException,
            string message, string stacktrace)
        {
            SourceException = sourceException;
            Message = message;
            Stacktrace = stacktrace;
        }
    }

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
