using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Termgine {
  class Program {
    private static void Main(string[] args) {

      StreamReader sr = new StreamReader("../../../Resources/mario.aa");
      // Read the stream to a string, and write the string to the console.
      var marioAA = sr.ReadToEnd();
      marioAA = marioAA.Replace("\r\n" , "\n");
      Console.WriteLine(marioAA);

      sr.Close();
      StreamReader sr2 = new StreamReader("../../../Resources/mario.mc");

      var marioMC = sr2.ReadToEnd().Replace("\r\n", "\n");

      sr2.Close();

      var mario = "1     ██████████        \n" +
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

      var marioColorMask = "      1111111111        \n" +
                           "    111111111111111111  \n" +
                           "    88888833338833      \n" +
                           "  88338833333388333333  \n" +
                           "  8833888833333388333333\n" +
                           "  88883333333388888888  \n" +
                           "      33333333333333    \n" +
                           "    11114411111111      \n" +
                           "  11111144111144111111  \n" +
                           "111111114444444411111111\n" +
                           "333311443344443344113333\n" +
                           "333333444444444444333333\n" +
                           "333344444444444444443333\n" +
                           "    444444    4444444   \n" +
                           "  888888         88888  \n" +
                           "88888888         8888888\n";

      // Scene setup
      var display = new Display(Display.MaxWidth/2, Display.MaxHeight/2);
      var image = new Image(new Vector2(0, 0), mario, marioColorMask);
      var scene = new Scene();
      scene.AddObject(image);
      display.HideCursor();
      display.AddScene(scene);
      display.Show();
      while (true) {
        //Thread.Sleep(100/15);
        display.WaitForKey();
        display.WaitForKey();
        display.Refresh();
      }
    }
  }
}
