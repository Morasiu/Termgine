using System;
using Xunit;

namespace Termgine.Tests {
    public class GameObjectTests {
        [Fact]
        public void Contructor_None_ShouldReturnGameObject() {
            var testGameObject = new GameObject();
            Assert.Equal("", testGameObject.Content);
            Assert.Equal("", testGameObject.ColorMask);
            Assert.Equal(new Vector2(0, 0), testGameObject.Position);
        }

        [Fact]
        public void Contructor_PositionAndContent_ShouldReturnGameObject() {
            var testGameObject = new GameObject(new Vector2(1, 1), "TEST");
            Assert.Equal("TEST", testGameObject.Content);
            Assert.Equal("9999", testGameObject.ColorMask); // Should set default ColorMask to '9'(white)
            Assert.Equal(new Vector2(1, 1), testGameObject.Position);
        }

        [Fact]
        public void Contructor_PositionContentAndColorMask_ShouldReturnGameObject() {
            var testGameObject = new GameObject(new Vector2(1, 1), "TEST", "1234");
            Assert.Equal("TEST", testGameObject.Content);
            Assert.Equal("1234", testGameObject.ColorMask);
            Assert.Equal(new Vector2(1, 1), testGameObject.Position);
        }

        [Fact]
        public void Contructor_PositionContentAndChar_ShouldReturnGameObject() {
            var testGameObject = new GameObject(new Vector2(1, 1), "TEST", '1');
            Assert.Equal("TEST", testGameObject.Content);
            Assert.Equal("1111", testGameObject.ColorMask);
            Assert.Equal(new Vector2(1, 1), testGameObject.Position);
        }

        [Fact]
        public void SetPosition_Vector2X1Y1_ShouldReturnVector2X1Y1() {
            var testGameObject = new GameObject();
            testGameObject.Position = new Vector2(1, 1);
            Assert.Equal(new Vector2(1, 1), testGameObject.Position);
        }

        [Fact]
        public void SetPosition_Vector2XMinus1Y1_ShouldThrowException() {
            var testGameObject = new GameObject();
            var wrongPosition = new Vector2(-1, 1);
            Assert.Throws<ArgumentOutOfRangeException>(() => testGameObject.Position = wrongPosition);
        }

        [Fact]
        public void SetContent_TestContent_ShouldReturnTestContent() {
            var testGameObject = new GameObject();
            testGameObject.Content = "TestContent";
            Assert.Equal("TestContent", testGameObject.Content);
        }

        [Fact]
        public void SetColorMask_TestColorMask_ShouldReturnTestColorMask() {
            var testGameObject = new GameObject();
            var testColorMask = "12345";
            testGameObject.ColorMask = testColorMask;
            Assert.Equal(testColorMask, testGameObject.ColorMask);
        }

        [Fact]
        public void GetWidth_Test_ShouldReturn4() {
            var testGameObject = new GameObject();
            testGameObject.Content = "Test";
            Assert.Equal(4, testGameObject.Width);
        }

        [Fact]
        public void GetWidth_MultilineContent_ShouldReturn4() {
            var testGameObject = new GameObject();
            testGameObject.Content = "Test\nLongerTest";
            Assert.Equal(10, testGameObject.Width);
        }

        [Fact]
        public void GetHeight_Test_ShouldReturn2() {
            var testGameObject = new GameObject();
            var testTwoLineContent = "Test\nTest";
            testGameObject.Content = testTwoLineContent;
            Assert.Equal(2, testGameObject.Height);
        }

        [Fact]
        public void SetColor_1_ShouldReturnColorMask1() {
            var testGameObject = new GameObject();
            testGameObject.Content = "Test";
            testGameObject.SetColor('1');
            Assert.Equal("1111", testGameObject.ColorMask);
        }
    }
}