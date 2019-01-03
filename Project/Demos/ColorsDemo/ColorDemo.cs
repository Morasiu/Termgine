using System;
using System.Linq;
using System.Threading;
using Termgine;

namespace ColorsDemo {
    class ColorDemo {
        static void Main(string[] args) {
            var display = new Display();
            var scene = new Scene();
            var colorsTestContent =
                "0 -> Black\n" +
                "1 -> Red\n" +
                "2 -> Green\n" +
                "3 -> Yellow\n" +
                "4 -> Blue\n" +
                "5 -> Magenta\n" +
                "6 -> Cyan\n" +
                "7 -> DarkYellow\n" +
                "8 -> Gray\n" +
                "9 -> White\n";
            var colorsTestColorMask =
                "0000000000\n" +
                "11111111\n" +
                "2222222222\n" +
                "33333333333\n" +
                "444444444\n" +
                "555555555555\n" +
                "666666666\n" +
                "777777777777777\n" +
                "888888888\n" +
                "9999999999\n";

            var colors = new Label(display.Center, colorsTestContent, colorsTestColorMask);
            var backgroudnColorLabel = new Label(colors.Position + Vector2.Up * 2, "Background color", '9');
            scene.AddObject(colors);
            scene.AddObject(backgroudnColorLabel);
            display.AddScene(scene);
            display.Show();
            display.WaitForKey();
            foreach (var color in Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>()) {
                display.CurrentScene.GameObjects[1].Content = color.ToString();
                display.BackgroundColor = color;
                display.Show();
                Thread.Sleep(500);
            }

            display.WaitForKey();
        }
    }
}