//
//  EnumerableUtils.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System.Linq;
using System.Collections.Generic;

namespace IdpGie {

    public static class EnumerableUtils {

        public static T SplitHead<T> (this IEnumerable<T> source, out IEnumerable<T> tail) {
            tail = source.Tail ();
            return source.FirstOrDefault ();
        }

        public static IEnumerable<T> Tail<T> (this IEnumerable<T> source) {
            IEnumerator<T> tor = source.GetEnumerator ();
            if (tor.MoveNext ()) {
                while (tor.MoveNext()) {
                    yield return tor.Current;
                }
            }
        }

        public static bool Empty<T> (this IEnumerable<T> source) {
            return !source.GetEnumerator ().MoveNext ();
        }

    }

}

