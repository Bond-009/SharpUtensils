/*
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace SharpUtensils.Net
{
    /// <summary>
    /// Extension methods for working with <see cref= "IPAddress" />.
    /// </summary>
    public static class IPAddressExtensions
    {
        /// <summary>
        /// The number of bytes needed to represent an IPv4 address.
        /// </summary>
        public const int IPv4AddressBytes = 4;

        /// <summary>
        /// The number of bytes needed to represent an IPv6 address.
        /// </summary>
        public const int IPv6AddressBytes = 16;

        /// <summary>
        /// Gets whether the address is a multicast global address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns><c>true</c> if the IP address is a multicast global address; otherwise, <c>false</c>.</returns>
        public static bool IsMultiCast(this IPAddress address)
            => address.IsIPv6Multicast || address.IsIPv4MultiCast();

        /// <summary>
        /// Gets whether the address is an IPv4 multicast global address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns><c>true</c> if the IP address is an IPv4 multicast global address; otherwise, <c>false</c>.</returns>
        public static bool IsIPv4MultiCast(this IPAddress address)
        {
            if (!address.IsIPv4())
            {
                return false;
            }

            Span<byte> bytes = stackalloc byte[IPv4AddressBytes];
            var result = address.TryWriteBytes(bytes, out int bytesWritten);
            Debug.Assert(result, "Failed to write IPAddress bytes to span.");
            Debug.Assert(
                bytesWritten == IPv4AddressBytes,
                $"Expected {nameof(bytesWritten)} to be {IPv4AddressBytes}, got {bytesWritten}");

            // Check if the most-significant bit pattern is 1110
            return (bytes[0] & 0xf0) == 0b11100000;
        }

        /// <summary>
        /// Gets whether the address is IPv4.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns><c>true</c> if the IP address is IPv4; otherwise, <c>false</c>.</returns>
        public static bool IsIPv4(this IPAddress address)
            => address.AddressFamily == AddressFamily.InterNetwork;

        /// <summary>
        /// Gets whether the address is IPv6.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns><c>true</c> if the IP address is IPv6; otherwise, <c>false</c>.</returns>
        public static bool IsIPv6(this IPAddress address)
            => address.AddressFamily == AddressFamily.InterNetworkV6;
    }
}
