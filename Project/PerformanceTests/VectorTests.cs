using BenchmarkDotNet.Attributes;
using Termgine;

namespace PerformanceTests {
    public class Vector2PerformanceTests {
        //[Benchmark]
        //public Vector2 Vector2Ctor() {
        //    return new Vector2(1, 1);
        //}

        [Benchmark]
        public bool Vector2Equals() {
            return Vector2.One == Vector2.Zero;
        }

        [Benchmark]
        public bool Vector2NotEquals() {
            return Vector2.One != Vector2.Zero;
        }

        [Benchmark]
        public Vector2 Substract() {
            return Vector2.One - Vector2.Left;
        }

        [Benchmark]
        public Vector2 Addition() {
            return Vector2.One + Vector2.Left;
        }

        [Benchmark]
        public bool Vector2OrgEquals() {
            return Termgine.Tested.Vector2.One == Termgine.Tested.Vector2.Zero;
        }

        [Benchmark]
        public bool Vector2OrgNotEquals() {
            return Termgine.Tested.Vector2.One != Termgine.Tested.Vector2.Zero;
        }

        [Benchmark]
        public Termgine.Tested.Vector2 SubstractOrg() {
            return Termgine.Tested.Vector2.One - Termgine.Tested.Vector2.Left;
        }

        [Benchmark]
        public Termgine.Tested.Vector2 AdditionOrg() {
            return Termgine.Tested.Vector2.One + Termgine.Tested.Vector2.Left;
        }
    }
}
