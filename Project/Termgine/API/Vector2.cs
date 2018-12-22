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

    public static Vector2 operator +(Vector2 v1, Vector2 v2) => new Vector2(v1.X + v2.X, v1.Y + v2.Y);

    public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1.X - v2.X, v1.Y - v2.Y);

  }
}