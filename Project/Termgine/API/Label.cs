namespace Termgine {
	public class Label : GameObject {

		#region Constructors
		public Label(Vector2 position, string content, char color) : base(position, content, color) {}

		public Label(Vector2 position, string content, string colorMask) : base(position, content, colorMask){}

		#endregion
	}
}