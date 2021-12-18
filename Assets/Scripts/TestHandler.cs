using Shapes;
using UnityEngine;

public class TestHandler : MonoBehaviour
{
    [SerializeField] private GameObject someObject;

    private bool flag = false;
    private void Start()
    {
        someObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flag = !flag;
            someObject.SetActive(flag);
            DrawMeSomething();
        }
    }

    private PolylinePath p;
    private void DrawMeSomething()
    {
        p = new PolylinePath();
        p.AddPoint( -1, -1 );
        p.AddPoint( -1,  1 );
        p.AddPoint(  1,  1 );
        p.AddPoint(  1, -1 );
        DrawShapes(Camera.main);
    }

    void DrawShapes( Camera cam ){
        using( Draw.Command( cam ) ){
            Draw.Polyline( p, closed:true, thickness:0.1f, Color.red ); // Drawing happens here
        }
    } 
    void OnDestroy() => p.Dispose();
}
