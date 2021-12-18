using System;
using System.Collections.Generic;
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
            var vec = Vector3.zero;
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

        public static Vector3 Vector2ToVector3(Vector2 pos) => new Vector3(pos.x, pos.y, 0);
        public static Vector2 Vector3ToVector2(Vector3 pos) => new Vector2(pos.x, pos.y);
        
    }
}
