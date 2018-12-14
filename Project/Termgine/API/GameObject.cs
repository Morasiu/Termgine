using System;
using System.Text;

namespace Termgine {
  public class GameObject {
    #region Public contructors

    public GameObject(Vector2 position, string content, string colorMask) : this (position, content) {
      ColorMask = colorMask;
    }

    public GameObject(Vector2 position, string content, char color) : this (position) {
      Content = content;
      SetColor(color);
    }

    private GameObject(Vector2 position, string content) : this (position) {
      Content = content;
    }

    #endregion

    #region Protected constructor

    protected GameObject(Vector2 position) {
      Position = position;
    }

    #endregion

    #region Public variables

    public Vector2 Position { get; set; }

    public string Content { get; set; }

    public string ColorMask { get; set;}

    #endregion

    #region Privates

    private void SetColor(char color) {
      var builder = new StringBuilder();
      for (var index = 0; index < Content.Length; index++) {
        if (Content[index] == '\n' || Content[index] == ' ') builder.Append(Content[index]);
        else builder.Append(color);
      }

      ColorMask = builder.ToString();
    }

    #endregion
  }
}