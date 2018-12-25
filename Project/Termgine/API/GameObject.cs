using System;
using System.Text;

namespace Termgine {
	public class GameObject {
		private Vector2 _position;
		#region Public contructors

		public GameObject(Vector2 position, string content, string colorMask) : this(position, content) {
			ColorMask = colorMask;
		}

		public GameObject(Vector2 position, string content) : this(position) {
			Content = content;
		}
		public GameObject(Vector2 position, string content, char color) : this(position, content) {
			SetColor(color);
		}


		public GameObject(string content) {
			Content = content;
			Position = Vector2.Zero;
		}

		#endregion

		#region Protected constructor

    protected GameObject(){
      Position = Vector2.Zero;
      Content = "";
      ColorMask = "";
    }

		protected GameObject(Vector2 position) {
			Position = position;
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
			for (var index = 0; index < Content.Length; index++)
			{
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
		#endregion
	}
}