using UnityEngine;
using Shapes;

namespace Tetris
{
    //[ExecuteAlways]
    public class ShapesDrawingComponent : ImmediateModeShapeDrawer
    {
        private void Start()
        {
            DrawShapes(Camera.main);
        }

        private PolylinePath line1;
        private Disc[] discs;
        private PolylinePath line2;
        private PolylinePath line3;
        private float x, y;
        public override void DrawShapes( Camera cam ){

            using( Draw.Command( cam ) )
            {
                Draw.LineGeometry = LineGeometry.Volumetric3D;
                Draw.ThicknessSpace = ThicknessSpace.Pixels;
                Draw.Thickness = 2; // 4px wide
                Draw.PolylineJoins = PolylineJoins.Round;

                var vectors = new Vector2[20];
                for (int i = 3; i < vectors.Length+3; i++)
                {
                    vectors[i] = new Vector2(i, i / 2);
                }

                discs = new Disc[vectors.Length];
                for (int i = 0; i < vectors.Length; i++)
                {
                    discs[i] = new Disc();
                }
                /*// set up static parameters. these are used for all following Draw.Line calls
                Draw.LineGeometry = LineGeometry.Volumetric3D;
                Draw.ThicknessSpace = ThicknessSpace.Pixels;
                Draw.Thickness = 4; // 4px wide

                // set static parameter to draw in the local space of this object
                Draw.Matrix = transform.localToWorldMatrix;
                line1 = new PolylinePath();
                line1.AddPoints(Vector3.zero);
                line1.AddPoints(Vector3.right);
                
                line2 = new PolylinePath();
                line2.AddPoints(Vector3.zero);
                line2.AddPoints(Vector3.up);
                
                line3 = new PolylinePath();
                line3.AddPoints(Vector3.zero);
                line3.AddPoints(Vector3.left);
                
                // draw lines
                Draw.Polyline(line1, true,0.1f, Color.red );
                Draw.Polyline(line2, true,0.1f, Color.green );
                Draw.Polyline(line3, true,0.1f, Color.blue );*/
            }

        }

        private void OnDestroy()
        {
            ClearAll();
        }

        public override void OnDisable()
        {
            ClearAll();
        }

        private void ClearAll()
        {
            line1.ClearAllPoints();
            line1.Dispose();
            /*line2.Dispose();
            line3.Dispose();*/
        }
    }
}
