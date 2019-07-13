using System;
using DefaultEcs;
using DefaultEcs.System;
using Termgine.API.Components;

namespace Termgine.API.Systems {
    [With(typeof(Render))]
    public class RenderSystem : AEntitySystem<float> {
        private int _count = 0;
        public RenderSystem(World world, SystemRunner<float> runner) : base(world, runner) { }

        protected override void Update(float elapsedTime, in Entity render) {
            ref var r = ref render.Get<Render>();
            _count++;
            Console.Clear();
            Console.WriteLine(_count + r.Content);
            var a = Console.ReadLine();
            r.Content = "Test" + a;
        }
    }
}