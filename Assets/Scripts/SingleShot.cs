using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace root
{
    [CreateAssetMenu(fileName = "SingleShot", menuName = "root/WeaponStrategy/SingleShot")]
    public class SingleShot : WeaponStrategy
    {
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            //var projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            var projectile = ObjectPool.instance.GetPoolObject();
            if (projectile != null) 
            {
                projectile.transform.position = firePoint.position;
                projectile.transform.rotation = firePoint.rotation;
                projectile.SetActive(true);
            }

            projectile.transform.SetParent(firePoint);
            projectile.layer = layer;

            var projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(projectileSpeed);

            //Destroy(projectile, projectileLifetime);
        }
    }
}
