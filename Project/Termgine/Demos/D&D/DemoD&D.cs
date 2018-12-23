using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace Termgine {
  class DemoMenu {
    private static void Main(string[] args) {
      var dragonAA = File.ReadAllText("./Demos/D&D/Resources/dragon.aa");
      var dragon = new Image(Vector2.Zero, dragonAA, '1');
      var leftDragonAA = File.ReadAllText("./Demos/D&D/Resources/leftDragon.aa");
      var leftDragon = new Image(Vector2.Zero, leftDragonAA, '1');
      // Scene setup
      var display = new Display();
      var scene = new Scene();
      var welcome = new Label("  Welcome to D&D  \n"+
                              " Terminal Edition "); 
      welcome.Position = Display.Center - new Vector2(welcome.GetWidth()/2, 0);
      welcome.SetColor('1');
      var menu = new Border(welcome, '6', BorderType.DoubleExtended);
      dragon.Position = menu.Position - new Vector2(-menu.GetWidth() - 1, dragon.GetHeight()/2);
      leftDragon.Position = new Vector2(dragon.Position.X - menu.GetWidth() - leftDragon.GetWidth() - 1, dragon.Position.Y);
      var a = dragon.GetHeight();
      scene.AddObject(menu);
      scene.AddObject(dragon);
      scene.AddObject(leftDragon);
      display.HideCursor();
      display.AddScene(scene);
      display.Show();
      display.WaitForKey();
    }
  }
}
