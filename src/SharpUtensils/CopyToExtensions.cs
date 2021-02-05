/*
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System.Collections.Generic;

namespace SharpUtensils
{
    /// <summary>
    /// Provides <c>CopyTo</c> extensions methods for <see cref="IReadOnlyList{T}" />
    /// and <see cref="IReadOnlyCollection{T}" />.
    /// </summary>
    public static class CopyToExtensions
    {
        /// <summary>
        /// Copies all the elements of the current collection to the specified list
        /// starting at the specified destination array index. The index is specified as a 32-bit integer.
        /// </summary>
        /// <param name="source">The current collection that is the source of the elements.</param>
        /// <param name="destination">The list that is the destination of the elements copied from the current collection.</param>
        /// <param name="index">A 32-bit integer that represents the index in <c>destination</c> at which copying begins.</param>
        /// <typeparam name="T">The type of elements in the collections.</typeparam>
        public static void CopyTo<T>(this IReadOnlyList<T> source, IList<T> destination, int index = 0)
        {
            int count = source.Count;
            for (int i = 0; i < count; i++)
            {
                destination[index + i] = source[i];
            }
        }

        /// <summary>
        /// Copies all the elements of the current collection to the specified list
        /// starting at the specified destination array index. The index is specified as a 32-bit integer.
        /// </summary>
        /// <param name="source">The current collection that is the source of the elements.</param>
        /// <param name="sourceIndex">The zero-based index in the source <see cref="IReadOnlyList{T}" /> at which copying begins.</param>
        /// <param name="destination">The list that is the destination of the elements copied from the current collection.</param>
        /// <param name="destinationIndex">The zero-based index in <c>destination</c> at which copying begins.</param>
        /// <typeparam name="T">The type of elements in the collections.</typeparam>
        public static void CopyTo<T>(
            this IReadOnlyList<T> source,
            int sourceIndex,
            IList<T> destination,
            int destinationIndex)
        {
            int count = source.Count - sourceIndex;
            for (int i = 0; i < count; i++)
            {
                destination[destinationIndex + i] = source[sourceIndex + i];
            }
        }

        /// <summary>
        /// Copies all the elements of the current collection to the specified list
        /// starting at the specified destination array index. The index is specified as a 32-bit integer.
        /// </summary>
        /// <param name="source">The current collection that is the source of the elements.</param>
        /// <param name="sourceIndex">The zero-based index in the source <see cref="IReadOnlyList{T}" /> at which copying begins.</param>
        /// <param name="destination">The list that is the destination of the elements copied from the current collection.</param>
        /// <param name="destinationIndex">The zero-based index in <c>destination</c> at which copying begins.</param>
        /// <param name="count">The number of elements to copy.</param>
        /// <typeparam name="T">The type of elements in the collections.</typeparam>
        public static void CopyTo<T>(
            this IReadOnlyList<T> source,
            int sourceIndex,
            IList<T> destination,
            int destinationIndex,
            int count)
        {
            if (source.Count - sourceIndex < count)
            {
                ThrowHelper.ThrowArgumentException(
                    "count is greater than the number of elements from index to the end of the source collection.");
            }

            for (int i = 0; i < count; i++)
            {
                destination[destinationIndex + i] = source[sourceIndex + i];
            }
        }

        /// <summary>
        /// Copies all the elements of the current collection to the specified list
        /// starting at the specified destination array index. The index is specified as a 32-bit integer.
        /// </summary>
        /// <param name="source">The current collection that is the source of the elements.</param>
        /// <param name="destination">The list that is the destination of the elements copied from the current collection.</param>
        /// <param name="index">A 32-bit integer that represents the index in <c>destination</c> at which copying begins.</param>
        /// <typeparam name="T">The type of elements in the collections.</typeparam>
        public static void CopyTo<T>(this IEnumerable<T> source, IList<T> destination, int index = 0)
        {
            foreach (T item in source)
            {
                destination[index++] = item;
            }
        }
    }
}
