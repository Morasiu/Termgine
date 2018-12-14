using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace Termgine {
  public class Display {
    #region Public constructors

    public Display() {
      Width = Console.WindowWidth;
      Height = Console.WindowHeight;
    }

    public Display(int width, int height) {
      Height = height;
      Width = width;
    }

    #endregion

    #region Public variables

    public static int MaxHeight => Console.LargestWindowHeight;
    public static int MaxWidth => Console.LargestWindowWidth;

    public int Height {
      get => _height;
      set {
        if (value < 1)
          throw new ArgumentException("Height too small");
        _height = value;
        OnWindowSizeChanged();
      }
    }

    public int Width {
      get => _width;
      set {
        if (value < 1)
          throw new ArgumentException("Width too small");
        _width = value;
        OnWindowSizeChanged();
      }
    }

    public List<Scene> Scenes;

    public Scene CurrentScene { get; set; }

    public ConsoleColor BackgroundColor = ConsoleColor.Black;

    #endregion

    #region Public methods

    public void AddScene(Scene scene) {
      if (Scenes == null) Scenes = new List<Scene>();
      Scenes.Add(scene);
    }

    public void Show() {
      Console.Clear();
      if (Scenes == null || Scenes.Count == 0) throw new ArgumentOutOfRangeException($"Scenes list is empty");
      if (Scenes.Count > 1 && CurrentScene == null) throw new ArgumentException("Set Current scene");
      else CurrentScene = Scenes[0];
      DrawCurrentScene();
    }

    public void Refresh() {
      DrawCurrentScene();
    }

    public void SetBackgroundColor(ConsoleColor color) {
      BackgroundColor = color;
      Console.BackgroundColor = color;
    }

    public void ShowCursor() {
      Console.CursorVisible = true;
    }

    public void HideCursor() {
      Console.CursorVisible = false;
    }

    public ConsoleKeyInfo WaitForKey() {
      return Console.ReadKey(true);
    }

    #endregion

    #region Private variables

    private int _height = Console.WindowHeight;

    private int _width = Console.WindowWidth;

    #endregion

    #region Private methods

    private void DrawCurrentScene() {
      Console.SetCursorPosition(0, 0);
      var currentContent = CurrentScene.Content.Split('\n');
      var currentColors = CurrentScene.ContentColors.Split('\n');

      for (var y = 0; y < CurrentScene.Height; y++) {
        for (var x = 0; x < CurrentScene.Width; x++) {
          var color = GetColorFromNumber(currentColors[y][x]);
          WriteInColor(currentContent[y][x], color);
        }
      }
    }

    private static void WriteInColor(char c, ConsoleColor color) {
      Console.ForegroundColor = color;
      Console.Write(c);
    }

    private ConsoleColor GetColorFromNumber(char c) {
      switch (c) {
        case ' ':
          return BackgroundColor;
        case '0':
          return ConsoleColor.Black;
        case '1':
          return ConsoleColor.Red;
        case '2':
          return ConsoleColor.Green;
        case '3':
          return ConsoleColor.Yellow;
        case '4':
          return ConsoleColor.Blue;
        case '5':
          return ConsoleColor.Magenta;
        case '6':
          return ConsoleColor.Cyan;
        case '7':
          return ConsoleColor.White;
        case '8':
          return ConsoleColor.DarkYellow;
        default:
          throw new ArgumentException("Wrong color mask: " + c);
      }
    }

    private void OnWindowSizeChanged() {
      Console.SetWindowSize(1, 1);
      Console.SetBufferSize(_width, _height);
      Console.SetWindowSize(_width, _height);
    }

    #endregion
  }
}