using Boot;
using UnityEngine;

namespace Decorations
{
    public sealed class ParalaxBehaviour : MonoBehaviour, IBoot
    {
        [SerializeField] private Transform followingTarget;
        private Vector3 targetPreviousPosition;
        [SerializeField, Range(0f, 1f)] private float paralaxStrength = 0.1f;
        [SerializeField] private bool disableVerticalParallax;

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SimpleImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        void IBoot.InitAwake()
        {
            if (!followingTarget)
                followingTarget = Camera.main.transform;

            targetPreviousPosition = transform.position;
        }

        private void FixedUpdate()
        {
            var delta = followingTarget.position - targetPreviousPosition;

            if (disableVerticalParallax)
                delta.y = 0;

            targetPreviousPosition = followingTarget.position;
            transform.position += delta * paralaxStrength;
        }
    }
}
