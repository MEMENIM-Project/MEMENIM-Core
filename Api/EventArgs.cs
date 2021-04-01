using System;

namespace Memenim.Core.Api
{
    public class CoreInformationEventArgs : EventArgs
    {
        public Exception SourceException { get; }
        private string _message;
        public string Message
        {
            get
            {
                return _message
                       ?? SourceException?.Message
                       ?? string.Empty;
            }
            private set
            {
                _message = value;
            }
        }

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
        private string _message;
        public string Message
        {
            get
            {
                return _message
                       ?? SourceException?.Message
                       ?? string.Empty;
            }
            private set
            {
                _message = value;
            }
        }

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
        private string _message;
        public string Message
        {
            get
            {
                return _message
                       ?? SourceException?.Message
                       ?? string.Empty;
            }
            private set
            {
                _message = value;
            }
        }

        public CoreErrorEventArgs(string message)
            : this(null, message)
        {

        }
        public CoreErrorEventArgs(Exception sourceException,
            string message = null)
        {
            SourceException = sourceException;
            Message = message;
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
