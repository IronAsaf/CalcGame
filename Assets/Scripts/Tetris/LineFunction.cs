using System.Collections.Generic;
using UnityEngine;

namespace Tetris
{
    public class LineFunction : AbstractFunction
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            currentFallingPositions = new List<Vector3>
            {
                new Vector3(0, 0, 0),
                new Vector3(1, 1, 0)
            };
            base.Awake();
        }
        void Start()
        {
            SetupGo(currentFallingPositions);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
