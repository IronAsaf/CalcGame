using UnityEngine;
using Utility;

namespace Tetris
{
    // maybe remove rigid and do update time.time to fall on its own with our own speed.
    [RequireComponent(typeof(Rigidbody2D))]
    public class FallingFunction : AbstractFunction
    {
        private Rigidbody2D rigidbody2DRef;
        private Vector2 startingPos;
        private bool shouldSpeedUp = false;
        private float speed = -1f;
        private float speedUp = -2f;
        private const float OldSpeed = -1f;
        protected override void Awake()
        {
            base.Awake();
            startingPos = transform.localPosition;
            rigidbody2DRef = GetComponent<Rigidbody2D>();
        }
        
        protected override void Start()
        {
            TetrisManager.Instance.onFunctionChangeEvent.AddListener(OnChangeEvent);
            TetrisManager.Instance.onGameEndEvent.AddListener(OnEndGame);
            TetrisManager.Instance.onFunctionSpeedUpEvent.AddListener(SpeedUpFalling);
            TetrisManager.Instance.onFunctionSlowDownEvent.AddListener(SlowDownFalling);
            TetrisManager.Instance.onFunctionFlipEvent.AddListener(OnFlipEvent);
            SetupInitialFallingFunction();
            base.Start();
        }

        private void OnFlipEvent()
        {
            currentFallingPositions = TetrisManager.Instance.FlipFallingFunction();
            SetupGo(currentFallingPositions);
        }
        private void OnChangeEvent()
        {
            currentFallingPositions = TetrisManager.Instance.ResetFallingFunction();
            SetupGo(currentFallingPositions);
        }
        protected override void OnFunctionsHitEvent()
        {
            speed = TetrisManager.Instance.GetNewFallingSpeed(speed);
            transform.SetPositionAndRotation(PositionsUtility.Vector2ToVector3(startingPos),Quaternion.identity);
            currentFallingPositions = TetrisManager.Instance.ResetFallingFunction();
            SetupGo(currentFallingPositions);
        }

        private void FixedUpdate()
        {
            float fall = shouldSpeedUp ? speedUp : speed;
            rigidbody2DRef.velocity = new Vector2(0, fall);
        }

        private void OnEndGame()
        {
            speed = 0f;
            speedUp = 0f;
        }

        protected override void RestartFunction()
        {
            SetupInitialFallingFunction();
            transform.SetPositionAndRotation(PositionsUtility.Vector2ToVector3(startingPos),Quaternion.identity);
            currentFallingPositions = TetrisManager.Instance.ResetFallingFunction();
            SetupGo(currentFallingPositions);
            speed = OldSpeed;
        }

        private void SpeedUpFalling()
        {
            shouldSpeedUp = true;
        }

        private void SlowDownFalling()
        {
            shouldSpeedUp = false;
        }
    }
}
