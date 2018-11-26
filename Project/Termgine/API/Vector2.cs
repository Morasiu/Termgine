namespace Termgine {
  public class Vector2 {
    public static Vector2 Zero => new Vector2(0, 0);

    public int X { get; set; }

    public int Y { get; set; }

    public Vector2(int x, int y) {
      X = x;
      Y = y;
    }
  }
}