namespace Termgine {
	class Label : GameObject {

		#region Constructors

		public Label(string content) : base(content) {}
		protected Label(Vector2 position) : base(position) {}
		public Label(Vector2 position, string content, char color) : base(position, content, color) {}

		public Label(Vector2 position, string content, string colorMask) : base(position, content, colorMask){}

		#endregion
	}
}