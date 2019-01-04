using System;
using System.Collections.Generic;
using System.Text;

namespace Termgine {
    public class Scene {
        #region Constructor

        public Scene() {
            Height = Console.WindowHeight;
            Width = Console.WindowWidth;
            GameObjects = new List<GameObject>();
        }

        #endregion

        #region Public variables

        public List<GameObject> GameObjects { get; set; }

        public int Width {
            get => _width;

            set {
                _width = value;
                OnSizeChanged();
            }
        }

        public int Height {
            get => _height;
            set {
                _height = value;
                OnSizeChanged();
            }
        }

        public string Content {
            get {
                // TODO More efficent instead of reseting all content
                var content = new StringBuilder();
                UpdateContent();
                foreach (var line in _content) {
                    content.Append(new string(line) + "\n");
                }
                return content.ToString();
            }
        }

        public string ColorMask {
            get {
                // TODO same as Content
                var colorMask = new StringBuilder();
                UpdateColorMask();
                foreach (var line in _colorMask) {
                    colorMask.Append(new string(line) + "\n");
                }
                return colorMask.ToString();
            }
        }

        #endregion

        #region Public methods

        public void AddObject(GameObject gameObject) {
            if (gameObject.Position.X > Width || gameObject.Position.Y > Height)
                throw new ArgumentException("Position set outside scene size");
            GameObjects.Add(gameObject);
            AddObjectToGlobalContent(gameObject.Content, gameObject.Position);
            AddObjectColorToGlobalColorMask(gameObject.ColorMask, gameObject.Position);
        }

        #endregion

        #region Private variables

        private int _width;
        private int _height;
        private char[][] _content;
        private char[][] _colorMask;

        #endregion

        #region Private methods

        private void AddObjectToGlobalContent(string gameObjectContent, Vector2 position) {
            if (gameObjectContent == null)return;
            var contentLines = gameObjectContent.Split('\n');
            for (var y = 0; y < contentLines.Length; y++) {
                var globalPositionY = y + position.Y;
                if (globalPositionY >= Height)continue;
                for (var x = 0; x < contentLines[y].Length; x++) {
                    var globalPositionX = x + position.X;
                    if (globalPositionX >= Width)break;
                    if (contentLines[y][x] != ' ' && contentLines[y][x] != '\0')
                        _content[globalPositionY][globalPositionX] = contentLines[y][x];
                }
            }
        }

        private void AddObjectColorToGlobalColorMask(string gameObjectColorMask, Vector2 position) {
            if (gameObjectColorMask == null)return;
            var contentLines = gameObjectColorMask.Split('\n');
            for (var y = 0; y < contentLines.Length; y++) {
                var globalPositionY = y + position.Y;
                if (globalPositionY >= Height)continue;
                for (var x = 0; x < contentLines[y].Length; x++) {
                    var globalPositionX = x + position.X;
                    if (globalPositionX >= Width)break;
                    if (contentLines[y][x] != ' ' && contentLines[y][x] != '\0')
                        _colorMask[globalPositionY][globalPositionX] = contentLines[y][x];
                }
            }
        }

        private void UpdateContent() {
            InitContent();
            foreach (var gameObject in GameObjects) {
                AddObjectToGlobalContent(gameObject.Content, gameObject.Position);
            }
        }

        private void UpdateColorMask() {
            InitColorMask();
            foreach (var gameObject in GameObjects) {
                AddObjectColorToGlobalColorMask(gameObject.ColorMask, gameObject.Position);
            }
        }

        private void OnSizeChanged() {
            InitContent();
            InitColorMask();
        }

        private void InitContent() {
            _content = new char[Height][];
            for (var i = 0; i < _content.Length; i++) {
                _content[i] = new char[Width];
                for (var index = 0; index < _content[i].Length; index++) {
                    _content[i][index] = ' ';
                }
            }
        }

        private void InitColorMask() {
            _colorMask = new char[Height][];
            for (var i = 0; i < _colorMask.Length; i++) {
                _colorMask[i] = new char[Width];
                for (var index = 0; index < _colorMask[i].Length; index++) {
                    _colorMask[i][index] = ' ';
                }
            }

        }

        #endregion
    }
}