using System;
using System.Runtime.CompilerServices;

namespace Termgine {
    public readonly struct Vector2 : IEquatable<Vector2> {
        #region Static variables
        //by making them readonly, we're not creating any new vectors, just grab ready made one
        public readonly static Vector2 Zero = new Vector2(0, 0);
        public readonly static Vector2 Up = new Vector2(0, -1);
        public readonly static Vector2 Down = new Vector2(0, 1);
        public readonly static Vector2 Left = new Vector2(-1, 0);
        public readonly static Vector2 Right = new Vector2(1, 0);
        public readonly static Vector2 One = new Vector2(1, 1);
        #endregion Static variables

        public Vector2(int x, int y) {
            X = x;
            Y = y;
        }

        //why not readonly fields?
        //https://codeblog.jonskeet.uk/2014/07/16/micro-optimization-the-surprising-inefficiency-of-readonly-fields/
        #region Public variables
        public int X { get; }
        public int Y { get; }
        #endregion Public variables

        #region Public methods
        public override bool Equals(object obj) {
            if(!(obj is Vector2))
                return false;
            return this == (Vector2) obj;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vector2 other) {
            return X == other.X && Y == other.Y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => (this.X, this.Y).GetHashCode();

        #endregion Public methods

        #region Operators
        // Vector2, Vector2
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator +(Vector2 v1, Vector2 v2) => new Vector2(v1.X + v2.X, v1.Y + v2.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1.X - v2.X, v1.Y - v2.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *(Vector2 v1, Vector2 v2) => new Vector2(v1.X * v2.X, v1.Y * v2.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(Vector2 v1, Vector2 v2) => new Vector2(v1.X / v2.X, v1.Y / v2.Y);

        public static bool operator ==(Vector2 v1, Vector2 v2) => v1.Equals(v2);

        public static bool operator !=(Vector2 v1, Vector2 v2) => !v1.Equals(v2);

        //Vector2, int
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator +(Vector2 v1, int i) => new Vector2(v1.X + i, v1.Y + i);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator -(Vector2 v1, int i) => new Vector2(v1.X - i, v1.Y - i);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *(Vector2 v1, int i) => new Vector2(v1.X * i, v1.Y * i);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(Vector2 v1, int i) => new Vector2(v1.X / i, v1.Y / i);

        //int, Vector2
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator +(int i, Vector2 v1) => new Vector2(i + v1.X, i + v1.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator -(int i, Vector2 v1) => new Vector2(i - v1.X, i - v1.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *(int i, Vector2 v1) => new Vector2(i * v1.X, i * v1.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(int i, Vector2 v1) => new Vector2(i / v1.X, i / v1.Y);

        // Vector2, tuple
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator +(Vector2 v1, (int, int) t) => new Vector2(v1.X + t.Item1, v1.Y + t.Item2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator -(Vector2 v1, (int, int) t) => new Vector2(v1.X - t.Item1, v1.Y - t.Item2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *(Vector2 v1, (int, int) t) => new Vector2(v1.X * t.Item1, v1.Y * t.Item2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(Vector2 v1, (int, int) t) => new Vector2(v1.X * t.Item1, v1.Y * t.Item2);

        // tuple, Vector2
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator +((int, int) t, Vector2 v1) => new Vector2(t.Item1 + v1.X, t.Item2 + v1.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator -((int, int) t, Vector2 v1) => new Vector2(t.Item1 - v1.X, t.Item2 - v1.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *((int, int) t, Vector2 v1) => new Vector2(t.Item1 * v1.X, t.Item2 * v1.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /((int, int) t, Vector2 v1) => new Vector2(t.Item1 * v1.X, t.Item2 * v1.Y);

        #endregion Operators
    }
}
