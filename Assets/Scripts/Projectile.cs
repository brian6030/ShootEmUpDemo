using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace root
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] GameObject hitPrefab;

        Transform parent;

        public void SetSpeed(float speed) => this.speed = speed;
        public void SetParent(Transform parent) => this.parent = parent;

        public Action Callback;

        void Update()
        {
            transform.SetParent(null);
            transform.position += transform.forward * (speed * Time.deltaTime);

            if (Callback != null)
            {
                Callback.Invoke();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag != "Wall") 
            {
                if (hitPrefab != null)
                {
                    ContactPoint contact = collision.contacts[0];
                    var hitVFX = Instantiate(hitPrefab, contact.point, Quaternion.identity);

                    // Destory particle system
                    DestoryParticleSystem(hitVFX);
                }

                // Enemy takes damage
                var plane = collision.gameObject.GetComponent<Plane>();
                if (plane != null)
                {
                    plane.TakeDamage(1);
                }
            }
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }


        void DestoryParticleSystem(GameObject hitVFX)
        {
            var ps = hitVFX.GetComponent<ParticleSystem>();

            if (ps == null)
            {
                ps = hitVFX.GetComponentInChildren<ParticleSystem>();
            }

            Destroy(hitVFX, ps.main.duration);
        }
    }
}
