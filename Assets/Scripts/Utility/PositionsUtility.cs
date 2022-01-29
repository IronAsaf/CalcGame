using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utility
{
    public static class PositionsUtility
    {
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

        public static Vector2 Center(List<Vector3> positions)
        {
            var newSize = new Vector2((MostLeftVector3(positions).x +
                                       MostRightVector3(positions).x)/2,
                (MostBottomVector3(positions).y +
                 MostTopVector3(positions).y)/2);
            return newSize;
        }

        public static Vector3 Vector2ToVector3(Vector2 pos) => new(pos.x, pos.y, 0);

        public static List<Vector2> MinMaxScalar(List<Vector2> positions, float manip)
        {
            var copy = positions.ToList();
            float[] xArray = new float[copy.Count];
            float[] yArray = new float[copy.Count];
            Vector2ListToDimensionsArray(copy, xArray, yArray);

            Vector2 maxValues = new Vector2(MaxValueFromArray(xArray), MaxValueFromArray(yArray));
            Vector2 minValues = new Vector2(MinValueFromArray(xArray), MinValueFromArray(yArray));

            for (var i = 0; i < copy.Count;i++)
            {
                Vector3 nPos = Vector3.zero;
                nPos.x = Scalar(minValues.x, maxValues.x, copy[i].x, manip);
                nPos.y = Scalar(minValues.y, maxValues.y, copy[i].y, manip);
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

        public static void Vector2ListToDimensionsArray(List<Vector2> copy, float[] X, float[] Y)
        {
            for (var i = 0; i < copy.Count; i++)
            {
                X[i] = copy[i].x;
                Y[i] = copy[i].y;
            }
        }
        private static float MinValueFromArray(float[] array)
        {
            Array.Sort(array);
            return array[0];
        }

        private static float Scalar(float min, float max, float val, float manipulator)
        {
            return manipulator*(val - min) / (max - min);
        }
        
    }
}
