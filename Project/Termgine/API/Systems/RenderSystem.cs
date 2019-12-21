using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using System;
using System.Text;
using Termgine.API.Components;
using Termgine.API.Extensions;

namespace Termgine.API.Systems {
    [With(typeof(Render))]
    internal class RenderSystem : AComponentSystem<float, Render> {
        internal RenderSystem(World world, IParallelRunner _runner) : base(world, _runner) {
            Console.CursorVisible = false;
        }

        protected override void Update(float elapsedTime, ref Render render) {
            if (!render.IsDynamic) {
                string[] lines = render.Content.GetLines();
                for (int i = 0; i < lines.Length; i++) {
                    Console.SetCursorPosition(render.X, render.Y + i);
                    Console.Write(lines[i]);
                }
            } 
        }
    }
}