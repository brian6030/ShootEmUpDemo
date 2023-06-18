using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace root
{
    public abstract class WeaponStrategy : ScriptableObject
    {
        //[SerializeField] int damage = 1;
        [SerializeField] float fireRate = 0.5f;
        [SerializeField] protected float projectileSpeed = 10f;
        [SerializeField] protected float projectileLifetime = 4f;
        [SerializeField] protected GameObject projectilePrefab;

        //public int Damage => damage;
        public float FireRate => fireRate;

        public virtual void Initialize()
        {
            // no-op
        }

        public abstract void Fire(Transform firePoint, LayerMask layer);

    }
}
