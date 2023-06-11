using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace root
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] GameObject muzzlePrefab;
        [SerializeField] GameObject hitPrefab;

        Transform parent;

        // Start is called before the first frame update
        void Start()
        {
            if (muzzlePrefab != null) { }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (hitPrefab != null) { }
        }
    }
}
