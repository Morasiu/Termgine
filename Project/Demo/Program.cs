using Termgine.API.Components;

namespace Demo {
    class Program {
        static void Main(string[] args) {
            var game = new GameSystem();
            var loading = game.World.CreateEntity();
            var loading2 = game.World.CreateEntity();
            loading.Set(new Render { Content = 
@"Loading
With New Line", X = 0, Y = 0 });
            loading2.Set(new Render { Content = @"Loading
With New Line2 ", X = 2, Y = 1 });
            game.Run();
        }
    }
}
