using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace root
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] GameObject muzzlePrefab;
        [SerializeField] GameObject hitPrefab;

        Transform parent;

        public void SetSpeed(float speed) => this.speed = speed;
        public void SetParent(Transform parent) => this.parent = parent;

        public Action Callback;

        // Start is called before the first frame update
        void Start()
        {
            if (muzzlePrefab != null) 
            {
                var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
                muzzleVFX.transform.forward = gameObject.transform.forward;
                muzzleVFX.transform.SetParent(parent);

                // Destory particle system
                DestoryParticleSystem(muzzleVFX);
            }
        }

        void Update()
        {
            transform.SetParent(null);
            transform.position += transform.forward * (speed * Time.deltaTime);

            Callback?.Invoke();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (hitPrefab != null) 
            {
                ContactPoint contact = collision.contacts[0];
                var hitVFX = Instantiate(hitPrefab, contact.point, Quaternion.identity);

                // Destory particle system
                DestoryParticleSystem(hitVFX);
            }

            Destroy(gameObject);
        }


        void DestoryParticleSystem(GameObject muzzleVFX)
        {
            var ps = muzzleVFX.GetComponent<ParticleSystem>();

            if (ps == null)
            {
                ps = muzzleVFX.GetComponentInChildren<ParticleSystem>();
            }

            Destroy(muzzleVFX, ps.main.duration);
        }
    }
}
