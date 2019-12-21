using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using System;
using Termgine.API.Systems;

namespace Demo {
    public class GameSystem {
        public World World { get; set; }

        private readonly IParallelRunner _runner;

        public GameSystem() {
            World = new World();
            _runner = new DefaultParallelRunner(Environment.ProcessorCount);
        }


        public void Run() {
            var gameTime = DateTime.Now;
            var sequentialSystem = new SequentialSystem<float>(
                new RenderSystem(World, _runner)
                );
            TimeSpan elapsedTime;
            while (true) {
                elapsedTime = DateTime.Now - gameTime;
                sequentialSystem.Update(elapsedTime.Ticks);
            }
        }
    }
}