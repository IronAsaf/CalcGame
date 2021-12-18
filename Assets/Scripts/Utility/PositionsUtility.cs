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
            var functionEdgesPositions = new float[4];
            for (var i = 0; i < positions.Count; i++)
            {
                if (positions[i].x < functionEdgesPositions[(int) Positions.Left])
                {
                    functionEdgesPositions[(int) Positions.Left] = positions[i].x;
                }
                else if (positions[i].x > functionEdgesPositions[(int) Positions.Right])
                {
                    functionEdgesPositions[(int) Positions.Right] = positions[i].x;
                }

                if (positions[i].y < functionEdgesPositions[(int) Positions.Bot])
                {
                    functionEdgesPositions[(int) Positions.Bot] = positions[i].y;
                }
                else if (positions[i].y > functionEdgesPositions[(int) Positions.Top])
                {
                    functionEdgesPositions[(int) Positions.Top] = positions[i].y;
                }
            }
            var newSize = new Vector2(
                Math.Abs(functionEdgesPositions[(int) Positions.Left]) +
                Math.Abs(functionEdgesPositions[(int) Positions.Right]),
                Math.Abs(functionEdgesPositions[(int) Positions.Bot]) +
                Math.Abs(functionEdgesPositions[(int) Positions.Top]));

            return newSize;
        }
    }
}
