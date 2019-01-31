using BenchmarkDotNet.Running;

namespace PerformanceTests {
    internal static class Program {
        private static void Main(string[] args) {
            BenchmarkRunner.Run<Vector2PerformanceTests>();
        }
    }
}
