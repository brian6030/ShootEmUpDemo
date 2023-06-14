using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace root
{
    public class EnermyWeapon : Weapon
    {
        float fireTimer;

        // Update is called once per frame
        void Update()
        {
            fireTimer += Time.deltaTime;

            if (fireTimer >= weaponStrategy.FireRate) 
            {
                weaponStrategy.Fire(firePoint, layer);
                fireTimer = 0f;
            }
        }
    }
}
