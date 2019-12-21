using System.Linq;
using Termgine.API.Extensions;

namespace Termgine.API.Components {
    public struct Render {
        public bool IsDynamic { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Content { get; set; }
        public int Width => Content.GetStringWidth();
        public int Height => Content.GetStringHeight();
    }
}