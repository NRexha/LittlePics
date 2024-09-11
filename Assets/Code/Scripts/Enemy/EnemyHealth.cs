using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IEnemyHealth
    {
        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private float _health = 100f;




        public void Die()
        {
            Destroy(gameObject);
        }

        public void Heal(float amount)
        {
            _health += amount;
        }

        public void Spawn()
        {
            _health = 100f;
        }
        

        public void TakeDamage(float amount, Vector3 impulseDirection)
        {
            _health -= amount;
            _rigidBody.AddForce(impulseDirection * amount, ForceMode.Impulse);

            
            

            if (_health <= 0)
            {
                Die();
            }
        }

        
    }
}
