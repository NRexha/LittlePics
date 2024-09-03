using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public interface IEnemyHealth
    {
        void Spawn();
        void Heal(float amount);
        void TakeDamage(float amount, Vector3 impulseDirection);
        void Die();
    }
}
