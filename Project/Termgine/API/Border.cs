using System;
using System.Text;

namespace Termgine {
	public class Border : GameObject {
		#region public Contructors

		public Border(GameObject gameObject, char borderColor) : this(gameObject, borderColor, BorderType.Simple) {}

		public Border(GameObject gameObject, char borderColor, BorderType borderType) {
			BorderType = borderType;
			Position = gameObject.Position;
			AddBorder(gameObject, borderColor, borderType);
		}

		#endregion

		#region Public variables

		public BorderType BorderType { get; }

		#endregion

		#region Private methods
		private void AddBorder(GameObject gameObject, char color, BorderType borderType) {
			AddBorderAroundContent(gameObject, borderType);
			AddBorderColorMask(gameObject, color);
		}

		private void AddBorderColorMask(GameObject gameObject, char color) {
			var newColorMask = new StringBuilder();
			newColorMask.Append(color);
			for (int i = 0; i < gameObject.Width; i++)newColorMask.Append(color);
			newColorMask.Append(color + "\n");
			var lines = gameObject.ColorMask.Split('\n');
			foreach (var line in lines) {
				newColorMask.Append(color);
				for (int j = 0; j < gameObject.Width; j++) {
					if (j < line.Length)newColorMask.Append(line[j]);
					else newColorMask.Append(' ');
				}
				newColorMask.Append(color + "\n");
			}
			newColorMask.Append(color);
			for (int i = 0; i < gameObject.Width; i++)newColorMask.Append(color);
			newColorMask.Append(color);
			ColorMask = newColorMask.ToString();
		}

		private void AddBorderAroundContent(GameObject gameObject, BorderType borderType) {
			char leftTopCorner;
			char rightTopCorner;
			char leftBottomCorner;
			char rightBottomCorner;
			char vertical;
			char horziontal;
			switch (borderType) {
				case BorderType.Simple:
					leftTopCorner = '+';
					rightTopCorner = '+';
					leftBottomCorner = '+';
					rightBottomCorner = '+';
					vertical = '|';
					horziontal = '-';
					break;
				case BorderType.Extended:
					leftTopCorner = '┌';
					rightTopCorner = '┐';
					leftBottomCorner = '└';
					rightBottomCorner = '┘';
					vertical = '│';
					horziontal = '─';
					break;
				case BorderType.DoubleExtended:
					leftTopCorner = '╔';
					rightTopCorner = '╗';
					leftBottomCorner = '╚';
					rightBottomCorner = '╝';
					vertical = '║';
					horziontal = '═';
					break;
				default:
					throw new NotImplementedException("Border type not implemented");
			}

			var newContent = new StringBuilder();
			newContent.Append(leftTopCorner);
			for (int i = 0; i < gameObject.Width; i++)newContent.Append(horziontal);
			newContent.Append(rightTopCorner + "\n");
			var lines = gameObject.Content.Split('\n');
			foreach (var line in lines) {
				newContent.Append(vertical);
				for (int j = 0; j < gameObject.Width; j++) {
					if (j < line.Length)newContent.Append(line[j]);
					else newContent.Append(' ');
				}
				newContent.Append(vertical + "\n");
			}
			newContent.Append(leftBottomCorner);
			for (int i = 0; i < gameObject.Width; i++)newContent.Append(horziontal);
			newContent.Append(rightBottomCorner);
			Content = newContent.ToString();
		}
		#endregion
	}

	public enum BorderType {
		Simple,
		Extended,
		DoubleExtended
	}
}