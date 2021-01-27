using System;
using System.Numerics;

namespace IntersectTwoLineSegment
{
    internal class Program
    {
        /// <summary>
        /// 線分を扱うクラスです。
        /// </summary>
        private class Segment
        {
            public Vector2 Start { get; set; }
            public Vector2 End { get; set; }
            private Vector2 Vector => End - Start;

            /// <summary>
            /// 二つの線分が交差しているか判定します。
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            public static bool Intersect(Segment a, Segment b)
            {
                var crossVector = Cross(a.Vector, b.Vector);
                // 外積が0になる場合は、ベクトルが平行
                if (crossVector == 0) return false;

                var t1 = Cross(b.Start - a.Start, a.Vector) / crossVector;
                var t2 = Cross(b.Start - a.Start, b.Vector) / crossVector;

                return 0 <= t1 && t1 <= 1 && 0 <= t2 && t2 <= 1;
            }

            /// <inheritdoc />
            public override string ToString()
            {
                return $"{nameof(Start)} = {Start},{nameof(End)} = {End}";
            }

            /// <summary>
            /// 二次元の外積を求めます。
            /// </summary>
            /// <remarks>
            /// 二次元は標準関数として用意されていないので、三次元の標準関数を流用
            /// </remarks>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            private static float Cross(Vector2 a, Vector2 b)
            {
                return Vector3.Cross(new Vector3(a.X, a.Y, 0), new Vector3(b.X, b.Y, 0)).Z;
            }
        }

        private static void Main(string[] args)
        {
            var a = new Segment
            {
                Start = Vector2.Zero,
                End = new Vector2(10, 10)
            };
            var b = new Segment
            {
                Start = new Vector2(-1, -1),
                End = new Vector2(-2, -3)
            };
            var result = (Segment.Intersect(a, b) ? "intersect" : "not") + $" ({a}) x ({b})";
            Console.WriteLine(result);
        }
    }
}