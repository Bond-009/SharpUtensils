/*
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;

namespace SharpUtensils
{
    /// <summary>
    /// Provides extensions methods for <see cref="Type" />.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Determines whether the current <see cref="Type" /> derives from the specified <see cref="Type" />.
        /// </summary>
        /// <param name="derivedType">To type to determine for whether it derives from <paramref name="baseType"/>.</param>
        /// <param name="baseType">The base type class for which the check is made.</param>
        /// <returns><c>true</c> if <paramref name="derivedType"/> derives from <paramref name="baseType"/>; otherwise <c>false</c>.</returns>
        public static bool IsSubclassOfRawGeneric(this Type? derivedType, Type baseType)
        {
            while (derivedType != null && derivedType != typeof(object))
            {
                Type currentType = derivedType.IsGenericType ? derivedType.GetGenericTypeDefinition() : derivedType;
                if (baseType == currentType)
                {
                    return true;
                }

                derivedType = derivedType.BaseType;
            }

            return false;
        }
    }
}
