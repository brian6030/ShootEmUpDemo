using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace root
{
    public class Enemy : Plane
    {
        protected override void Die()
        {
            GameManager.Instance.AddScore(10);
            Destroy(gameObject);
        }
    }
}
