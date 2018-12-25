using System;
using System.Text;

namespace Termgine {
	public class GameObject {
		#region Public contructors

		public GameObject(){
      Position = Vector2.Zero;
      Content = "";
      ColorMask = "";
    }

		public GameObject(Vector2 position, string content) {
			Position = position;
			Content = content;
			SetColor('7'); // White
		}

		public GameObject(Vector2 position, string content, string colorMask) : this(position, content) {
			ColorMask = colorMask;
		}

		public GameObject(Vector2 position, string content, char color) : this(position, content) {
			SetColor(color);
		}

		#endregion

		#region Public variables

		public Vector2 Position { get => _position; 
      set {
        if(value.X < 0 || value.Y < 0)
          throw new ArgumentOutOfRangeException("Position cannot be less than zero");
        _position = value;
        }
    }

		public string Content { get; set; }

		public string ColorMask { get; set; }

		#endregion

		#region Public methods

		public void SetColor(char color) {
			var builder = new StringBuilder();
			for (var index = 0; index < Content.Length; index++) {
				if (Content[index] == '\n' || Content[index] == ' ') builder.Append(Content[index]);
				else builder.Append(color);
			}

			ColorMask = builder.ToString();
		}

    public int GetHeight() {
      return Content.Split("\n").Length;
    }

    public int GetWidth() {
      var lines = Content.Split('\n');
      int maxWidth = 0;
      foreach (var line in lines) {
        if (line.Length > maxWidth) {
          maxWidth =  line.Length;
        }
      }

      return maxWidth;
    }

		#endregion

		#region Private variables

		private Vector2 _position;

		#endregion
	}
}