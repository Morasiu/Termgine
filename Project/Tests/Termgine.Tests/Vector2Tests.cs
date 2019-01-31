using System;
using Xunit;

namespace Termgine.Tests {
    public class Vector2Tests {

        #region Statics

        [Fact]
        public void Vector2Zero_None_ShouldReturnVector2WithX0Y0() {
            Assert.Equal(0, Vector2.Zero.X);
            Assert.Equal(0, Vector2.Zero.Y);
        }

        [Fact]
        public void Vector2Up_None_ShouldReturnVector2WithX0YMinus1() {
            Assert.Equal(0, Vector2.Up.X);
            Assert.Equal(-1, Vector2.Up.Y);
        }

        [Fact]

        public void Vector2Down_None_ShouldReturnVector2WithX0Y1() {
            Assert.Equal(0, Vector2.Down.X);
            Assert.Equal(1, Vector2.Down.Y);
        }

        [Fact]
        public void Vector2Left_None_ShouldReturnVector2WithXMinus1Y0() {
            Assert.Equal(-1, Vector2.Left.X);
            Assert.Equal(0, Vector2.Left.Y);
        }

        [Fact]
        public void Vector2Right_None_ShouldReturnVector2WithX1Y0() {
            Assert.Equal(1, Vector2.Right.X);
            Assert.Equal(0, Vector2.Right.Y);
        }

        #endregion

        #region Contructors

        [Fact]
        public void Contructor_X1Y1_ShouldReturnVector2WithX1y1() {
            var result = new Vector2(1, 1);
            Assert.Equal(1, result.X);
            Assert.Equal(1, result.Y);
        }

        #endregion

        #region Operators

        [Fact]
        public void AddVectors_Vector2_ShouldReturnVector2X2Y2() {
            var testVector = new Vector2(1, 1) + new Vector2(1, 1);
            Assert.Equal(new Vector2(2, 2), testVector);
        }

        [Fact]
        public void SubstarctVectors_Vector2_ShouldReturnVector2X1Y1() {
            var testVector = new Vector2(3, 3) - new Vector2(2, 2);
            Assert.Equal(new Vector2(1, 1), testVector);
        }

        [Fact]
        public void MultiplyVectors_Vector2_ShouldReturnVector2X6Y6() {
            var testVector = new Vector2(2, 2) * new Vector2(3, 3);
            Assert.Equal(new Vector2(6, 6), testVector);
        }

        [Fact]
        public void DivideVectors_Vector2_ShouldReturnVector2X2Y2() {
            var testVector = new Vector2(6, 6) / new Vector2(3, 3);
            Assert.Equal(new Vector2(2, 2), testVector);
        }

        [Fact]
        public void EqualsVectors_Vector2_ShouldReturnTrue() {
            var testVector = new Vector2(1, 1);
            var equalVector = new Vector2(1, 1);
            Assert.True(testVector == equalVector);
            Assert.True(testVector.Equals(equalVector));
        }

        [Fact]
        public void EqualsVectors_Vector2_ShouldReturnFalse() {
            var testVector = new Vector2(1, 1);
            var notEqualVector = new Vector2(2, 2);
            Assert.False(testVector == notEqualVector);
            Assert.False(testVector.Equals(notEqualVector));
        }

        [Fact]
        public void NotEqualsVectors_Vector2_ShouldReturnTrue() {
            var testVector = new Vector2(1, 1);
            var notEqualVector = new Vector2(2, 2);
            Assert.True(testVector != notEqualVector);
        }

        [Fact]
        public void NotEqualsVectors_Vector2_ShouldReturnFalse() {
            var testVector = new Vector2(1, 1);
            var equalVector = new Vector2(1, 1);
            Assert.False(testVector != equalVector);
        }

        #endregion
    }
}