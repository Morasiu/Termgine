using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using DefaultEcs;
using DefaultEcs.System;
using Termgine.API.Components;
using Termgine.API.Systems;

namespace Demo {
    public class Game {
        public void Run() {
            var gameTime = DateTime.Now;
            var world = new World();
            var entity = world.CreateEntity();
            var e1 = world.CreateEntity();
            e1.Set(new Render(){Content = "AAAA"});
            entity.Set(new Render() { Content = "Test" });
            var systemRunner = new SystemRunner<float>(Environment.ProcessorCount);
            var renderSystem = new RenderSystem(world, systemRunner) { };
            var sys = new SequentialSystem<float>(renderSystem);
            while (true) {
                Thread.Sleep(100);
                var elapsedTime = DateTime.Now - gameTime;
                sys.Update((float) elapsedTime.TotalSeconds);
            }
        }
    }

}