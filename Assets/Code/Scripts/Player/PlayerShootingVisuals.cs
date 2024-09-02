using UnityEngine;

namespace Player
{
    public class PlayerShootingVisuals : MonoBehaviour
    {
        [Header("Animator Parameters")]
        [SerializeField] private string _shootParameter = "IsShooting";
        private Animator _animator;

        private void Awake()
        {
            _animator = PlayerComponents.Instance.Animator;
        }

        private void OnEnable()
        {
            PlayerShooting.OnShootChanged += UpdateShootParameter;
        }

        private void OnDisable()
        {
            PlayerShooting.OnShootChanged -= UpdateShootParameter;
        }

        private void UpdateShootParameter(bool isShooting)
        {
            _animator.SetBool(_shootParameter, isShooting);
        }
    }
}
