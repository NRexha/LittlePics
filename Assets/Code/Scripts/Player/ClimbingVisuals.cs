using General;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using System.Collections;

namespace Player
{
    public class ClimbingVisuals : MonoBehaviour
    {
        [Header("IK Settings")]
        [SerializeField] private TwoBoneIKConstraint _leftHand;
        [SerializeField] private TwoBoneIKConstraint _rightHand;
        [SerializeField] private float _handOffsetX = 0.2f;
        [SerializeField] private float _ikTransitionTime = 0.2f;

        [Header("References")]
        [SerializeField] private string _climbAnimationTrigger = "Climb";

        private void OnEnable()
        {
            LedgeDetection.OnClimbStart += PlaceHands;
        }

        private void OnDisable()
        {
            LedgeDetection.OnClimbStart -= PlaceHands;
        }

        private void PlaceHands(Vector3 highestPoint, Vector3 targetPosition)
        {
            Vector3 playerRight = transform.right;

            Vector3 leftHandTarget = highestPoint - playerRight * _handOffsetX;
            Vector3 rightHandTarget = highestPoint + playerRight * _handOffsetX;

            if (_leftHand != null && _rightHand != null)
            {
                StartCoroutine(SmoothIKWeight(_leftHand, 1f, _ikTransitionTime));
                StartCoroutine(SmoothIKWeight(_rightHand, 1f, _ikTransitionTime));

                _leftHand.data.target.position = leftHandTarget;
                _rightHand.data.target.position = rightHandTarget;
            }
        }

        private IEnumerator SmoothIKWeight(TwoBoneIKConstraint ikConstraint, float targetWeight, float duration)
        {
            float initialWeight = ikConstraint.weight;
            float timer = 0f;

            while (timer < duration)
            {
                ikConstraint.weight = Mathf.Lerp(initialWeight, targetWeight, timer / duration);
                timer += Time.deltaTime;
                yield return null;
            }

            ikConstraint.weight = targetWeight;

            if (targetWeight == 1f)
            {
                yield return StartCoroutine(UpdateIKTargetsDuringClimb(ikConstraint));
            }
        }

        private IEnumerator UpdateIKTargetsDuringClimb(TwoBoneIKConstraint ikConstraint)
        {
            Animator animator = PlayerComponents.Instance.Animator;
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            while (stateInfo.IsName(_climbAnimationTrigger))
            {
                yield return null;
                stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            }

            StartCoroutine(SmoothIKWeight(ikConstraint, 0f, _ikTransitionTime));
        }
    }
}
