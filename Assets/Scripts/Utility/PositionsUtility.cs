using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utility
{
    public static class PositionsUtility
    {
        private enum Positions
        {
            Top, Bot, Left, Right
        }
        /// <summary>
        /// This function calculates the most left, right, top, and bottom x's and y's from a given list of vectors.
        /// </summary>
        /// <param name="positions">A list of Vector3 positions that need to find their bounds.</param>
        /// <returns>returns a vector2 where the X is the width and Y is the height.</returns>
        public static Vector2 SizeFromList(List<Vector3> positions)
        {
            var newSize = new Vector2(
                Math.Abs(MostLeftVector3(positions).x) +
                Math.Abs(MostRightVector3(positions).x),
                Math.Abs(MostBottomVector3(positions).y) +
                Math.Abs(MostTopVector3(positions).y));

            return newSize;
        }

        public static Vector3 MostTopVector3(List<Vector3> positions)
        {
            if (positions == null) return Vector3.negativeInfinity;
            var vec = positions[0];
            for (var i = 0; i < positions.Count; i++)
            {
                if (positions[i].y > vec.y)
                {
                    vec = positions[i];
                }
            }
            return vec;
        }
        
        public static Vector3 MostBottomVector3(List<Vector3> positions)
        {
            var vec = Vector3.zero;
            for (var i = 0; i < positions.Count; i++)
            {
                if (positions[i].y < vec.y)
                {
                    vec = positions[i];
                }
            }

            return vec;
        }
        
        public static Vector3 MostRightVector3(List<Vector3> positions)
        {
            var vec = Vector3.zero;
            for (var i = 0; i < positions.Count; i++)
            {
                if (positions[i].x > vec.x)
                {
                    vec = positions[i];
                }
            }

            return vec;
        }
        
        public static Vector3 MostLeftVector3(List<Vector3> positions)
        {
            var vec = Vector3.zero;
            for (var i = 0; i < positions.Count; i++)
            {
                if (positions[i].x < vec.x)
                {
                    vec = positions[i];
                }
            }

            return vec;
        }

        /// <summary>
        /// Finds within the list of Vector3 the position that is closest to the center.
        /// </summary>
        /// <param name="positions">the list of vector3 that are needed to be handled.</param>
        /// <returns>Vector3 of the most closest to the center</returns>
        public static Vector3 ClosestToCentralPosition(List<Vector3> positions)
        {
            var newSize = Vector3ToVector2(Center(positions));
            return newSize;
        }
        
        public static Vector2 Center(List<Vector3> positions)
        {
            var newSize = new Vector2((MostLeftVector3(positions).x +
                                       MostRightVector3(positions).x)/2,
                (MostBottomVector3(positions).y +
                 MostTopVector3(positions).y)/2);
            return newSize;
        }

        public static Vector3 Vector2ToVector3(Vector2 pos) => new(pos.x, pos.y, 0);
        public static Vector2 Vector3ToVector2(Vector3 pos) => new(pos.x, pos.y);

        public static Vector2 MaxVectorByMag(Vector2 v, Vector2 u)
        {
            if (v.magnitude > u.magnitude) return v;
            return u;
        }
        public static List<Vector3> NormalizePositions(List<Vector3> positions, float resizeScalar = 1f)
        {
            var copy = positions.ToList();
            for (var i = 0; i < copy.Count; i++)
            {
                var a = copy[i].sqrMagnitude;
                copy[i] *= resizeScalar / a;
            }
            
            return copy;
        }

        public static List<Vector2> MinMaxScalar(List<Vector2> positions)
        {
            var copy = positions.ToList();
            float[] xArray = new float[copy.Count];
            float[] yArray = new float[copy.Count];
            for (int i = 0; i < copy.Count; i++)
            {
                xArray[i] = copy[i].x;
                yArray[i] = copy[i].y;
            }

            Vector2 maxValues = new Vector2(MaxValueFromArray(xArray), MaxValueFromArray(yArray));
            Vector2 minValues = new Vector2(MinValueFromArray(xArray), MinValueFromArray(yArray));

            for (var i = 0; i < copy.Count;i++)
            {
                Vector3 nPos = Vector3.zero;
                nPos.x = Scalar(minValues.x, maxValues.x, copy[i].x);
                nPos.y = Scalar(minValues.y, maxValues.y, copy[i].y);
                copy[i] = nPos;
            }

            return copy;
        }

        private static float MaxValueFromArray(float[] array)
        {
            Array.Sort(array);
            var max = array[array.Length - 1];
            return max;
        }
        
        private static float MinValueFromArray(float[] array)
        {
            Array.Sort(array);
            return array[0];
        }

        private static float Scalar(float min, float max, float val)
        {
            return (val - min) / (max - min);
        }
        
    }
}
