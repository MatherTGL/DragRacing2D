using Boot;
using Player.Movement;
using UnityEngine;

namespace Decorations
{
    public sealed class ParalaxBehaviour : MonoBehaviour, IBoot
    {
        private PlayerMovementControl followingTarget;

        private Transform playerCameraTransform;

        private Vector3 targetPreviousPosition;

        [SerializeField, Range(0f, 1f)] private float paralaxStrength = 0.1f;

        private bool disableVerticalParallax = true;


        void IBoot.InitAwake()
        {
            if (!followingTarget)
                followingTarget = FindObjectOfType<PlayerMovementControl>();

            playerCameraTransform = followingTarget.GetComponentInChildren<Camera>().transform;
            targetPreviousPosition = transform.position;
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SimpleImportant, Bootstrap.TypeSingleOrLotsOf.LotsOf);
        }

        private void FixedUpdate()
        {
            var delta = playerCameraTransform.position - targetPreviousPosition;

            if (disableVerticalParallax)
                delta.y = 0;

            targetPreviousPosition = playerCameraTransform.position;
            transform.position += delta * paralaxStrength;
        }
    }
}
