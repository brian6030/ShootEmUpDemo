using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace root
{
    public class PlayerWeapon : Weapon
    {
        InputReader input;
        float fireTimer;

        private void Awake()
        {
            input = GetComponent<InputReader>();
        }

        // Update is called once per frame
        void Update()
        {
            fireTimer += Time.deltaTime;

            if (input.Fire && fireTimer >= weaponStrategy.FireRate)
            {
                weaponStrategy.Fire(firePoint, layer);
                fireTimer = 0f;
            }
        }
    }
}
