using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using System;
using Termgine.API.Components;

namespace Termgine.API.Systems {
    [With(typeof(Render))]
    public class RenderSystem : AComponentSystem<float, Render> {
        public RenderSystem(World world, IParallelRunner _runner) : base(world, _runner) { }

        protected override void Update(float elapsedTime, ref Render render) {
            Console.SetCursorPosition(render.X, render.Y);
            Console.Write(render.Content);
        }
    }
}