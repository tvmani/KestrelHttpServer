// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Server.Kestrel.Internal.Http;

namespace Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure
{
    public static class EventSourceExtensions
    {
        public static void ConnectionStart(this KestrelEventSource eventSource, Connection connection)
        {
            // avoid allocating strings unless this event source is enabled
            if (eventSource.IsEnabled())
            {
                eventSource.ConnectionStart(
                    connection.ConnectionId,
                    connection.ListenerContext.ListenOptions.Scheme,
                    connection.LocalEndPoint.ToString(),
                    connection.RemoteEndPoint.ToString());
            }
        }

        public static void ConnectionStop(this KestrelEventSource eventSource, Connection connection)
        {
            if (eventSource.IsEnabled())
            {
                eventSource.ConnectionStop(connection.ConnectionId);
            }
        }
    }
}
