//
//  TermBase.cs
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
using System;
using System.Collections.Generic;

namespace IdpGie {

    public class TermBase : NameBase {

        private int arity;

        public int Arity {
            get {
                return this.arity;
            }
        }

        public TermBase (string name, int arity) : base(name) {
            if (name == null || name == string.Empty) {
                throw new ArgumentNullException ("The name of a function or predicate must be effective.", "name");
            } else if (arity < 0x00 || arity > 0xff) {
                throw new ArgumentException ("The arity of a function must be larger or equal to zero and lower than 256.", "arity");
            }
            this.arity = arity;
        }

        public override string ToString () {
            return string.Format ("{0}/{1}", this.Name, this.Arity);
        }

        public virtual string TermString (List<FunctionInstance> terms) {
            if (terms.Count > 0x00) {
                return string.Format ("{0}({1})", this.Name, string.Join (",", terms));
            } else {
                return this.Name;
            }
        }

    }
}

