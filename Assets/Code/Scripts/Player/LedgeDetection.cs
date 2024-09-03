using General;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System;

namespace Player
{
    public class LedgeDetection : MonoBehaviour
    {
        [Header("Climb Parameters")]
        [SerializeField] private LayerMask _ledgeLayer;
        [SerializeField] private float _forwardOffset = 0.5f;
        [SerializeField] private float _climbHeightOffset = 0.1f;
        [SerializeField] private int _rayCount = 10;
        [SerializeField] private float _rayLength = 1f;
        [SerializeField] private float _climbMaxHeight;
        [SerializeField] private float _enableMovementAfterDelay = 1.35f;
        private Vector3 _targetPosition;
        private RaycastHit _highestHit;

        [Header("References")]
        [SerializeField] private string _climbAnimationTrigger = "Climb";
        private PlayerInputs _playerInputs;
        private CharacterController _characterController;

        public static event Action<Vector3, Vector3> OnClimbStart;

        private void Awake()
        {
            _playerInputs = PlayerComponents.Instance.PlayerInputs;
            _characterController = PlayerComponents.Instance.CharacterController;
        }

        private void OnEnable()
        {
            _playerInputs.InGame.Climb.performed += OnClimb;
        }

        private void OnDisable()
        {
            _playerInputs.InGame.Climb.performed -= OnClimb;
        }

        private void OnClimb(InputAction.CallbackContext context)
        {
            if (CheckForClimb())
            {
                StartClimb();
            }
        }

        private bool CheckForClimb()
        {
            Transform playerTransform = transform;
            Vector3 rayOrigin = playerTransform.position;
            Vector3 direction = playerTransform.forward;
            float playerHeight = _climbMaxHeight;
            float step = playerHeight / _rayCount;
            _highestHit = new RaycastHit();
            float highestHitPoint = float.MinValue;
            bool canClimb = false;

            for (int i = 0; i <= _rayCount; i++)
            {
                Vector3 rayStart = rayOrigin + Vector3.up * (i * step);
                if (Physics.Raycast(rayStart, direction, out RaycastHit hit, _rayLength, _ledgeLayer))
                {
                    if (hit.point.y > highestHitPoint)
                    {
                        highestHitPoint = hit.point.y;
                        _highestHit = hit;
                    }
                }
            }

            if (_highestHit.collider != null)
            {
                Vector3 maxHeightRayOrigin = playerTransform.position + Vector3.up * playerHeight;
                if (Physics.Raycast(maxHeightRayOrigin, direction, _rayLength, _ledgeLayer))
                {
                    canClimb = false;
                }
                else
                {
                    _targetPosition = _highestHit.point + Vector3.up * _climbHeightOffset + direction * _forwardOffset;
                    canClimb = true;
                }
            }
            else
            {
                canClimb = false;
            }

            return canClimb;
        }


        private void StartClimb()
        {
            
            Animator animator = PlayerComponents.Instance.Animator;
            if (animator != null)
            {
                animator.SetTrigger(_climbAnimationTrigger);
            }

            _characterController.enabled = false;
            OnClimbStart?.Invoke(_highestHit.point, _targetPosition);
            StartCoroutine(LerpToPosition(_targetPosition));
        }

        private IEnumerator LerpToPosition(Vector3 targetPosition)
        {
            Transform playerTransform = transform;
            float timer = 0f;
            float duration = 1f;
            Vector3 startingPosition = playerTransform.position;

            while (timer < duration)
            {
                playerTransform.position = Vector3.Lerp(startingPosition, targetPosition, timer / duration);
                timer += Time.deltaTime;
                yield return null;
            }

            playerTransform.position = targetPosition;

            yield return StartCoroutine(WaitForAnimationToFinish());
            yield return new WaitForSeconds(_enableMovementAfterDelay);
            FinishClimb();
        }

        private IEnumerator WaitForAnimationToFinish()
        {
            Animator animator = PlayerComponents.Instance.Animator;
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            while (stateInfo.IsName(_climbAnimationTrigger))
            {
                yield return null;
                stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            }
        }

        private void FinishClimb()
        {
            _characterController.enabled = true;
            PlayerComponents.Instance.PlayerMovementScript.SetSpeed(0f);

        }

      
        private void OnDrawGizmos()
        {
            if (!Application.isPlaying) return;

            Gizmos.color = Color.red;
            Transform playerTransform = transform;
            Vector3 rayOrigin = playerTransform.position;
            Vector3 direction = playerTransform.forward;
            float playerHeight = _climbMaxHeight;
            float step = playerHeight / _rayCount;

           
            for (int i = 0; i <= _rayCount; i++)
            {
                Vector3 rayStart = rayOrigin + Vector3.up * (i * step);
                Gizmos.DrawRay(rayStart, direction * _rayLength);
            }

            if (_highestHit.collider != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(_highestHit.point, 0.1f);

                
                Gizmos.color = Color.blue;
                Vector3 maxHeightRayOrigin = playerTransform.position + Vector3.up * playerHeight;
                Gizmos.DrawRay(maxHeightRayOrigin, direction * _rayLength);
            }
        }


    }
}
