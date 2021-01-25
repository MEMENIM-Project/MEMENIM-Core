using System;

namespace Memenim.Core.Api
{
    internal enum RequestType : byte
    {
        Get = 1,
        Post = 2
    }

    public enum ConnectionStateType : byte
    {
        Connected = 1,
        Disconnected = 2
    }
}
