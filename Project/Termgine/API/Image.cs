using System;

namespace Termgine {
  public class Image : GameObject {
    #region Constructors

    public Image(Vector2 position) : base(position) {
    }

    public Image(Vector2 position, string content, char color) : base (position, content, color) {
    }

    public Image(Vector2 position, string content, string colorMask) : base(position, content, colorMask) {
    }

    #endregion

    #region Public variables

    public ushort Width => GetWidth();
    public ushort Height => GetHeight();

    #endregion

    #region Public methods

    public ushort GetHeight() {
      return (ushort) Content.Split("\n").Length;
    }

    public ushort GetWidth() {
      var lines = Content.Split("/n");
      ushort maxWidth = 0;
      foreach (var line in lines) {
        if (line.Length > maxWidth) {
          maxWidth = (ushort) line.Length;
        }
      }

      return maxWidth;
    }

    #endregion
  }
}