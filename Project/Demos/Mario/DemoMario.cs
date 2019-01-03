using System;
using System.IO;
using Termgine;

namespace DemoMario {
  class DemoMario {
    private static void Main(string[] args) {
      var mario =
        "      ██████████        \n" +
        "    ██████████████████  \n" +
        "    ██████████████      \n" +
        "  ████████████████████  \n" +
        "  ██████████████████████\n" +
        "  ████████████████████  \n" +
        "      ██████████████    \n" +
        "    ██████████████      \n" +
        "  ████████████████████  \n" +
        "████████████████████████\n" +
        "████████████████████████\n" +
        "████████████████████████\n" +
        "████████████████████████\n" +
        "    ██████    ███████   \n" +
        "  ██████         █████  \n" +
        "████████         ███████\n";

      var marioColorMask =
        "      1111111111        \n" +
        "    111111111111111111  \n" +
        "    00000033330033      \n" +
        "  00330033333300333333  \n" +
        "  0033000033333300333333\n" +
        "  00003333333300000000  \n" +
        "      33333333333333    \n" +
        "    11114411111111      \n" +
        "  11111144111144111111  \n" +
        "111111114444444411111111\n" +
        "333311443344443344113333\n" +
        "333333444444444444333333\n" +
        "333344444444444444443333\n" +
        "    444444    4444444   \n" +
        "  000000         00000  \n" +
        "00000000         0000000\n";

      // Scene setup
      var display = new Display();
      var image = new Image(display.Center, mario, marioColorMask);
      var scene = new Scene();
      scene.AddObject(image);
      display.HideCursor();
      display.AddScene(scene);
      display.BackgroundColor = ConsoleColor.White;
      display.Show();
      display.WaitForKey();
    }
  }
}