using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace Termgine {
    public class Display {
        #region Public constructors

        public Display() {}

        #endregion

        #region Public variables

        public int Height => _height;

        public int Width => _width;

        public List<Scene> Scenes { get; set; }

        public Scene CurrentScene { get; set; }

        public ConsoleColor BackgroundColor {
            get => _backgroundColor;
            set {
                _backgroundColor = value;
                Console.BackgroundColor = value;
            }
        }
        public Vector2 LeftTopCorner { get; } = Vector2.Zero;

        public Vector2 RightTopCorner { get; } = new Vector2(Console.WindowWidth, 0);

        public Vector2 LeftBottomCorner { get; } = new Vector2(0, Console.WindowHeight);

        public Vector2 RightBottomCornet { get; } = new Vector2(Console.WindowWidth, Console.WindowHeight);

        public Vector2 Center { get; } = new Vector2(Console.WindowWidth / 2, Console.WindowHeight / 2);

        #endregion

        #region Public methods

        public void AddScene(Scene scene) {
            if (Scenes == null) {
                Scenes = new List<Scene>();
                CurrentScene = scene;
            }
            Scenes.Add(scene);
        }

        public void Show() {
            Console.Clear();
            DrawCurrentScene();
        }

        public void Refresh() {
            DrawCurrentScene();
        }

        public void ShowCursor() {
            Console.CursorVisible = true;
        }

        public void HideCursor() {
            Console.CursorVisible = false;
        }

        public ConsoleKeyInfo WaitForKey() => Console.ReadKey(true);

        #endregion

        #region Static variables

        public static int MaxHeight = Console.LargestWindowHeight;
        public static int MaxWidth = Console.LargestWindowWidth;

        #endregion

        #region Private variables

        private int _height = Console.WindowHeight;

        private int _width = Console.WindowWidth;
        private ConsoleColor _backgroundColor = Console.BackgroundColor;

        #endregion

        #region Private methods

        private void DrawCurrentScene() {
            if (CurrentScene == null)throw new NullReferenceException("CurrentScene is null");
            Console.SetCursorPosition(0, 0);
            var currentContent = CurrentScene.Content.Split('\n');
            var currentColors = CurrentScene.ColorMask.Split('\n');

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
                    return ConsoleColor.DarkYellow;
                case '8':
                    return ConsoleColor.Gray;
                case '9':
                    return ConsoleColor.White;
                default:
                    throw new ArgumentException("Wrong color mask: " + c);
            }
        }

        private void OnWindowSizeChanged() {
            // "Linux support" It's just magic
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))return;
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(_width, _height);
            Console.SetWindowSize(_width, _height);
        }

        #endregion
    }
}