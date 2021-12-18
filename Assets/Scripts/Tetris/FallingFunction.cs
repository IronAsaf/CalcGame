using System.Collections.Generic;
using UnityEngine;

namespace Tetris
{
    public class FallingFunction : MonoBehaviour
    {
        // Start is called before the first frame update
        private List<Vector3> currentFallingPositions;
        [SerializeField] private List<GameObject> functionDotsGORefs;
        private void Start()
        {
            SetupInitialFallingFunction();
        }

        private void SetupInitialFallingFunction()
        {
            currentFallingPositions = TetrisManager.instance.GetNewFallingFunctionListPositions();

            if (currentFallingPositions == null) return;

            functionDotsGORefs = new List<GameObject>();
            for (var i = 0; i < currentFallingPositions.Count; i++)
            {
                var go = new GameObject();
                Instantiate(go, currentFallingPositions[i], Quaternion.identity, transform);
                functionDotsGORefs.Add(go);
            }

        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }

    internal class ArrayList<T>
    {
    }
}
