using System.Runtime.InteropServices;

namespace Termgine {
  public class Vector2 {
    public static Vector2 Zero => new Vector2(0, 0);

    public int X { get; set; }

    public int Y { get; set; }

    public Vector2(int x, int y) {
      X = x;
      Y = y;
    }

    #region Operators

    // Vector2, Vector2
    public static Vector2 operator +(Vector2 v1, Vector2 v2) => new Vector2(v1.X + v2.X, v1.Y + v2.Y);
    public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1.X - v2.X, v1.Y - v2.Y);
    public static Vector2 operator *(Vector2 v1, Vector2 v2) => new Vector2(v1.X * v2.X, v1.Y - v2.Y);
    //Vector2, int
    public static Vector2 operator +(Vector2 v1, int i) => new Vector2(v1.X + i, v1.Y + i);
    public static Vector2 operator -(Vector2 v1, int i) => new Vector2(v1.X - i, v1.Y - i);
    public static Vector2 operator *(Vector2 v1, int i) => new Vector2(v1.X * i, v1.Y * i);
    // Vector2, tuple
    public static Vector2 operator +(Vector2 v1, (int, int) t) => new Vector2(v1.X + t.Item1, v1.Y + t.Item2);
    public static Vector2 operator -(Vector2 v1, (int, int) t) => new Vector2(v1.X - t.Item1, v1.Y - t.Item2);
    public static Vector2 operator *(Vector2 v1, (int, int) t) => new Vector2(v1.X * t.Item1, v1.Y * t.Item2);
   // tuple, Vector2
    public static Vector2 operator +((int, int) t, Vector2 v1) => new Vector2(t.Item1 + v1.X, t.Item2 + v1.Y);    
    public static Vector2 operator -((int, int) t, Vector2 v1) => new Vector2(t.Item1 - v1.X, t.Item2 - v1.Y);
    public static Vector2 operator *((int, int) t, Vector2 v1) => new Vector2(t.Item1 * v1.X, t.Item2 * v1.Y);

    #endregion
  }
}