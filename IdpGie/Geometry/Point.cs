//
//  Point.cs
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
using Cairo;
using OpenTK;
using IdpGie.Logic;

namespace IdpGie.Geometry {

    [FunctionStructure("point",TermType.Point)]
    public struct Point {

        private double x;
        private double y;
        private double z;

        public double X {
            get {
                return x;
            }
            set {
                this.x = value;
            }
        }

        public double Y {
            get {
                return y;
            }
            set {
                this.y = value;
            }
        }

        public double Z {
            get {
                return this.z;
            }
            set {
                this.z = value;
            }
        }

        [FunctionStructureConstructor(TermType.Float,TermType.Float)]
        public Point (double x, double y) : this(x,y,0.0d) {

        }

        [FunctionStructureConstructor(TermType.Float,TermType.Float,TermType.Float)]
        public Point (double x, double y, double z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void Transform (Matrix4d m) {
            double newx = this.x * m.M11 + this.y * m.M12 + this.z * m.M13 + m.M14;
            double newy = this.x * m.M21 + this.y * m.M22 + this.z * m.M23 + m.M24;
            double newz = this.x * m.M31 + this.y * m.M32 + this.z * m.M33 + m.M34;
            this.x = newx;
            this.y = newy;
            this.z = newz;
        }

        public void Transform (Matrix4 m) {
            double newx = this.x * m.M11 + this.y * m.M12 + this.z * m.M13 + m.M14;
            double newy = this.x * m.M21 + this.y * m.M22 + this.z * m.M23 + m.M24;
            double newz = this.x * m.M31 + this.y * m.M32 + this.z * m.M33 + m.M34;
            this.x = newx;
            this.y = newy;
            this.z = newz;
        }

        public void Transform (Matrix m) {
            double newx = this.x * m.Xx + this.y * m.Xy + m.X0;
            double newy = this.x * m.Yx + this.y * m.Yy + m.Y0;
            this.x = newx;
            this.y = newy;
        }

        public override bool Equals (object obj) {
            if (obj is Point) {
                Point p = (Point)obj;
                return (this.X == p.X && this.Y == p.Y && this.Z == p.Z);
            }
            return base.Equals (obj);
        }

        public override int GetHashCode () {
            return base.GetHashCode () ^ this.X.GetHashCode () ^ (this.Y.GetHashCode () << 0x0b) ^ (this.Z.GetHashCode () << 0x16);
        }

        public override string ToString () {
            return string.Format ("({0} ; {1} ; {2})", this.X, this.Y, this.Z);
        }

        public static explicit operator PointD (Point v) {
            return new PointD (v.x, v.y);
        }

        public static explicit operator Point (PointD v) {
            return new Point (v.X, v.Y);
        }

        public static explicit operator Point (Vector2 v) {
            return new Point (v.X, v.Y);
        }

        public static explicit operator Point (Vector2d v) {
            return new Point (v.X, v.Y);
        }

        public static explicit operator Point (Vector3 v) {
            return new Point (v.X, v.Y, v.Z);
        }

        public static explicit operator Point (Vector3d v) {
            return new Point (v.X, v.Y, v.Z);
        }

    }

}