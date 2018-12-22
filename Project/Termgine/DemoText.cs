using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Termgine {
  class DemoText {
    private static void AMain(string[] args) {

      // Scene setup
      var display = new Display();
      var scene = new Scene();
      var welcome = new Label("Welcome  to Deepmind");
      welcome.Position = Display.Center - new Vector2(welcome.GetWidth()/2, 0);
      welcome.SetColor('6');
      var simple = new Border(welcome, '6', BorderType.Simple);
      var extended = new Border(simple, '1', BorderType.Extended);
      var doubleExtended = new Border(extended, '5', BorderType.DoubleExtended);
      scene.AddObject(doubleExtended);
      display.HideCursor();
      display.AddScene(scene);
      display.Show();
      display.WaitForKey();
    }
  }
}
