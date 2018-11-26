namespace Termgine {
  public class GameObject {
    public Vector2 Position { get; set; }

    public string Content { get; set; }

    public string ColorMask { get; set;}

    public GameObject(Vector2 position, string content, string colorMask) : this (position, content) {
      ColorMask = colorMask;
    }

    public GameObject(Vector2 position, string content) : this (position) {
      Content = content;
    }

    protected GameObject(Vector2 position) {
      Position = position;
    }
  }
}