using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Termgine {
  public class Display {
    public static ushort MaxHeight => (ushort) Console.LargestWindowHeight;
    public static ushort MaxWidth => (ushort) Console.LargestWindowWidth;

    public ushort Height {
      get => _height;
      set {
        _height = value;
        OnWindowSizeChanged();
      }
    }

    public ushort Width {
      get => _width;
      set {
        _width = value;
        OnWindowSizeChanged();
      }
    }

    public Display(ushort height, ushort width) {
      _height = height;
      _width = width;
    }

    public Display(ushort height, ushort width, bool maximizeOnStart) : this(height, width) {
      if (maximizeOnStart) Maximize();
    }

    public List<Scene> Scenes;

    public Scene CurrentScene { get; set; }

    public ConsoleColor BackgroundColor = ConsoleColor.Black;

    public static void Maximize() {
      var p = Process.GetCurrentProcess();
      ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
    }

    public void AddScene(Scene scene) {
      if (Scenes == null) Scenes = new List<Scene>();
      Scenes.Add(scene);
    }

    public void Start() {
      Console.Clear();
      if (Scenes == null || Scenes.Count == 0) throw new ArgumentOutOfRangeException($"Scenes list is empty");
      if (Scenes.Count > 1 && CurrentScene == null) throw new ArgumentException("Current scene is not set");
      else CurrentScene = Scenes[0];
      Console.SetCursorPosition(0, 0);
      DrawCurrentScene();
    }

    private void DrawCurrentScene() {
      var currentContent = CurrentScene.Content.Split('\n');
      var currentColors = CurrentScene.ContentColors.Split('\n');

      for (var y = 0; y < CurrentScene.Height; y++) {
        for (var x = 0; x < CurrentScene.Width; x++) {
          var color = GetColorFromNumber(currentColors[y][x]);
          WriteInColor(currentContent[y][x], color);
        }
      }
    }

    private ConsoleColor GetColorFromNumber(char c) {
      switch (c) {
          case ' ':
            return Console.ForegroundColor;
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

    private static void WriteInColor(char c, ConsoleColor color) {
      Console.ForegroundColor = color;
      Console.Write(c);
    }

    public void SetBackgroundColor(ConsoleColor color) {
      BackgroundColor = color;
      Console.BackgroundColor = color;
    }

    private ushort _height;

    private ushort _width;

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

    private void OnWindowSizeChanged() {
      Console.SetWindowSize(1, 1);
      Console.SetBufferSize(_width, _height);
      Console.SetWindowSize(_width, _height);
    }
  }
}