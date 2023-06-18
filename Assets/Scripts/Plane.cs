using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace root
{
    public abstract class Plane : MonoBehaviour
    {
        [SerializeField] int maxHealth;
        int health;

        protected virtual void Awake()
        {
            health = maxHealth;
        }

        public void SetMaxHealth(int amount)
        {
            maxHealth = amount;
        }

        public void TakeDamage(int amount)
        {
            health -= amount;
            Debug.Log(health);

            if (health <= 0)
            {
                Die();
            }
        }
        public float GetHealthNormalized()
        {
            return health / (float) maxHealth;
        }

        protected abstract void Die();
    }
}
