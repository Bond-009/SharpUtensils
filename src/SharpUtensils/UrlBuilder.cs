/*
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System.Text;

namespace SharpUtensils
{
    /// <summary>
    /// Provides an abstraction on top of <see cref="StringBuilder"/>
    /// to easily create urls with as little overhead as possible.
    /// </summary>
    public sealed class UrlBuilder
    {
        /// <summary>
        /// The default capacity of a <see cref="UrlBuilder"/>.
        /// </summary>
        internal const int DefaultCapacity = 128;

        private readonly StringBuilder _strBuilder;

        private int _pathLength;

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlBuilder"/> class.
        /// </summary>
        public UrlBuilder() : this(DefaultCapacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlBuilder"/> class.
        /// </summary>
        /// <param name="capacity">The initial capacity of this builder.</param>
        public UrlBuilder(int capacity)
        {
            _strBuilder = new StringBuilder("?", capacity);
            _pathLength = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlBuilder"/> class.
        /// </summary>
        /// <param name="basePath">The base url used.</param>
        public UrlBuilder(string basePath) : this(basePath, DefaultCapacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlBuilder"/> class.
        /// </summary>
        /// <param name="basePath">The base url used.</param>
        /// <param name="capacity">The initial capacity of this builder.</param>
        public UrlBuilder(string basePath, int capacity)
        {
            _strBuilder = new StringBuilder(basePath, capacity);
            _strBuilder.Append('?');
            _pathLength = basePath.Length;
        }

        /// <summary>
        /// Adds the parameter to the query of the url.
        /// </summary>
        /// <param name="key">The key of the parameter.</param>
        /// <param name="values">the values of the parameter.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public UrlBuilder AddParameter(string key, params string[] values)
        {
            _strBuilder.Append(key)
                .Append('=');
            for (int i = 0; i < values.Length; i++)
            {
                _strBuilder.Append(values[i])
                    .Append(',');
            }

            // Replace last comma with a '&'
            _strBuilder[^1] = '&';
            return this;
        }

        /// <summary>
        /// Adds the parameter to the query of the url.
        /// </summary>
        /// <param name="key">The key of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public UrlBuilder AddParameter(string key, string value)
        {
            _strBuilder.Append(key)
                .Append('=')
                .Append(value)
                .Append('&');
            return this;
        }

        /// <summary>
        /// Adds the parameter to the query of the url.
        /// </summary>
        /// <param name="key">The key of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public UrlBuilder AddParameter(string key, decimal value)
        {
            _strBuilder.Append(key)
                .Append('=')
                .Append(value)
                .Append('&');
            return this;
        }

        /// <summary>
        /// Adds the parameter to the query of the url.
        /// </summary>
        /// <param name="key">The key of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public UrlBuilder AddParameter(string key, double value)
        {
            _strBuilder.Append(key)
                .Append('=')
                .Append(value)
                .Append('&');
            return this;
        }

        /// <summary>
        /// Adds the parameter to the query of the url.
        /// </summary>
        /// <param name="key">The key of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public UrlBuilder AddParameter(string key, float value)
        {
            _strBuilder.Append(key)
                .Append('=')
                .Append(value)
                .Append('&');
            return this;
        }

        /// <summary>
        /// Adds the parameter to the query of the url.
        /// </summary>
        /// <param name="key">The key of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public UrlBuilder AddParameter(string key, long value)
        {
            _strBuilder.Append(key)
                .Append('=')
                .Append(value)
                .Append('&');
            return this;
        }

        /// <summary>
        /// Adds the parameter to the query of the url.
        /// </summary>
        /// <param name="key">The key of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public UrlBuilder AddParameter(string key, int value)
        {
            _strBuilder.Append(key)
                .Append('=')
                .Append(value)
                .Append('&');
            return this;
        }

        /// <summary>
        /// Adds the parameter to the query of the url.
        /// </summary>
        /// <param name="key">The key of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public UrlBuilder AddParameter(string key, short value)
        {
            _strBuilder.Append(key)
                .Append('=')
                .Append(value)
                .Append('&');
            return this;
        }

        /// <summary>
        /// Adds the parameter to the query of the url.
        /// </summary>
        /// <param name="key">The key of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public UrlBuilder AddParameter(string key, byte value)
        {
            _strBuilder.Append(key)
                .Append('=')
                .Append(value)
                .Append('&');
            return this;
        }

        /// <summary>
        /// Appends the string segment to the base url.
        /// </summary>
        /// <param name="value">The string being added to the base url.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public UrlBuilder AppendPath(string value)
        {
            _strBuilder.Insert(_pathLength, value);
            _pathLength += value.Length;
            return this;
        }

        /// <summary>
        /// Appends the path segment to the base url.
        /// </summary>
        /// <param name="value">The string being added to the base url.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public UrlBuilder AppendPathSegment(string value)
        {
            _strBuilder.Insert(_pathLength++, '/')
                .Insert(_pathLength, value);
            _pathLength += value.Length;
            return this;
        }

        /// <inheritdoc />
        public override string ToString()
            => _strBuilder.ToString(0, _strBuilder.Length - 1);
    }
}
