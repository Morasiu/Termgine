using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace Termgine {
  class DemoDnD {
    static Display display = new Display();

    private static void Main(string[] args) {
      var welcomeScene = SetupWelcomeScene();
      display.HideCursor();
      display.AddScene(welcomeScene);
      display.Show();
      display.WaitForKey();
      var dragonTalkScene = SetupDragonTalkScene();
      display.AddScene(dragonTalkScene);
      display.CurrentScene = dragonTalkScene;
      display.Refresh();
      display.WaitForKey();
    }

    private static Scene SetupDragonTalkScene() {
      var scene = new Scene();
      var dragonFace = new Image(Vector2.Zero, File.ReadAllText("Resources/dragonFace.aa").Replace("\r", ""), '1');
      dragonFace.Position = display.Center - dragonFace.Width / 2 + Vector2.Right * 20;
      var talk = "You are finally awake.\n" +
        "I'm Malfor, the Elder Red Dragon.\n" +
        "You are not from this world.\n" +
        "What is your name?            ->";
      var dragonTalk = new Border(new Label(Vector2.Zero, talk, '7'), '7', BorderType.Extended);
      dragonTalk.Position = display.Center + Vector2.Left * 30 + Vector2.Up * 10;
      scene.AddObject(dragonFace);
      scene.AddObject(dragonTalk);
      return scene;
    }

    private static Scene SetupWelcomeScene() {
      var rightDragon = new Image(Vector2.Zero, File.ReadAllText("Resources/rightDragon.aa").Replace("\r", ""), '1');
      var leftDragon = new Image(Vector2.Zero, File.ReadAllText("Resources/leftDragon.aa").Replace("\r", ""), '1');
      var scene = new Scene();
      var welcome = new Label(Vector2.Zero,
        "  Welcome to D&D  \n" +
        " Terminal Edition ",
        '1');
      welcome.Position = display.Center - new Vector2(welcome.Width / 2, 0);
      var welcomeWithBorder = new Border(welcome, '6', BorderType.DoubleExtended);
      rightDragon.Position = welcomeWithBorder.Position - new Vector2(-welcomeWithBorder.Width - 1, rightDragon.Height / 2);
      leftDragon.Position = new Vector2(rightDragon.Position.X - welcomeWithBorder.Width - leftDragon.Width - 1, rightDragon.Position.Y);
      var pressAnyKey = new Label(Vector2.Zero, "Press any key to start...", '5');
      pressAnyKey.Position = welcomeWithBorder.Position + Vector2.Down * 7 + Vector2.Left;
      scene.AddObject(welcomeWithBorder);
      scene.AddObject(rightDragon);
      scene.AddObject(leftDragon);
      scene.AddObject(pressAnyKey);
      return scene;
    }

  }
}