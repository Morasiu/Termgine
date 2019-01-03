using System;
using System.Linq;
using System.Text;

namespace Termgine {
	public class GameObject {
		#region Public contructors

		public GameObject() {
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

		public Vector2 Position {
			get => _position;
			set {
				if (value.X < 0 || value.Y < 0)
					throw new ArgumentOutOfRangeException("Position cannot be less than zero");
				_position = value;
			}
		}

		public string Content { get; set; }

		public string ColorMask { get; set; }

		public int Width => Content.Split('\n').Max(line => line.Length);

		public int Height => Content.Split('\n').Length;

		#endregion

		#region Public methods

		public void SetColor(char color) {
			var charValue = Convert.ToInt16(color);
			if (charValue < 48 || charValue > 57)throw new ArgumentException("Color not recognized");
			var builder = new StringBuilder();
			for (var index = 0; index < Content.Length; index++) {
				if (Content[index] == '\n' || Content[index] == ' ')builder.Append(Content[index]);
				else builder.Append(color);
			}
			ColorMask = builder.ToString();
		}

		#endregion

		#region Private variables

		private Vector2 _position;

		#endregion
	}
}