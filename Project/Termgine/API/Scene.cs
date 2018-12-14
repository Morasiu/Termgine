using System;
using System.Collections.Generic;

namespace Termgine {
  public class Scene {
    #region Constructor

    public Scene() {
      Height = Console.WindowHeight;
      Width =  Console.WindowWidth;
      GameObjects = new List<GameObject>();
    }

    #endregion

    #region Public variables

    public List<GameObject> GameObjects;

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
        var content = "";
        foreach (var line in _content) {
          content += new string(line) + "\n";
        }

        return content;
      }
    }

    public string ContentColors {
      get {
        var colorMask = "";
        foreach (var line in _colorMask) {
          colorMask += new string(line) + "\n";
        }

        return colorMask;
      }
    }

    #endregion

    #region Public methods

    public void AddObject(GameObject o) {
      AddObjectAt(o, o.Position);
    }

    public void AddObjectAt(GameObject o, Vector2 position) {
      if (position.X > Width || position.Y > Height)
        throw new ArgumentException("Position set outside scene size");

      o.Position = position;
      GameObjects.Add(o);
      AddObjectToGlobalContent(o.Content, position);
      AddObjectColorToGlobalColorMask(o.ColorMask, position);
    }

    #endregion

    #region Private

    private void AddObjectToGlobalContent(string content, Vector2 position) {
      var contentLines = content.Split('\n');
      for (var y = 0; y < contentLines.Length; y++) {
        var globalPositionY = y + position.Y;
        if (globalPositionY >= Height) continue;
        for (var x = 0; x < contentLines[y].Length; x++) {
          var globalPositionX = x + position.X;
          if (globalPositionX >= Width) break;
          if (contentLines[y][x] != ' ')
            _content[globalPositionY][globalPositionX] = contentLines[y][x];
        }
      }
    }

    private void AddObjectColorToGlobalColorMask(string colorMask, Vector2 position) {
      var contentLines = colorMask.Split('\n');
      for (var y = 0; y < contentLines.Length; y++) {
        var globalPositionY = y + position.Y;
        if (globalPositionY >= Height) continue;
        for (var x = 0; x < contentLines[y].Length; x++) {
          var globalPositionX = x + position.X;
          if (globalPositionX >= Height) break;
          if (contentLines[y][x] != ' ')
            _colorMask[globalPositionY][globalPositionX] = contentLines[y][x];
        }
      }
    }

    private int _width;
    private int _height;
    private char[][] _content;
    private char[][] _colorMask;

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