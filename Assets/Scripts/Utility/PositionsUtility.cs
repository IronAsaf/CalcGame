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
            var max = array[^1]; // end of array basically.
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

        public static List<Vector2> RecenterAdjustmentValue(List<Vector2> pos)
        {
            var copy = pos.ToList();
            var len = copy.Count;
            float[] x = new float[len], y = new float[len];
            Vector2ListToDimensionsArray(copy, x, y);
            Array.Sort(x);
            Array.Sort(y);
            var adj = new Vector2(x[len / 2], y[len / 2]);
            for (var i = 0; i < len; i++)
            {
                copy[i] = new Vector2(copy[i].x - adj.x, copy[i].y - adj.y);
            }
            
            //return ;
            return copy;
        }
    }
}
