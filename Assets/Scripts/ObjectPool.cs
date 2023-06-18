using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace root
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] WeaponStrategy weaponStrategy;

        public static ObjectPool instance;

        List<GameObject> poolObjeccts = new List<GameObject>();
        [SerializeField] int amountToPool = 100;

        GameObject bulletPrefab;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            bulletPrefab = weaponStrategy.projectilePrefab;
            Debug.Log(bulletPrefab);

            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = Instantiate(bulletPrefab);
                obj.SetActive(false);
                poolObjeccts.Add(obj);
            }
        }

        public GameObject GetPoolObject()
        {
            for (int i = 0; i < poolObjeccts.Count; i++)
            {
                if (!poolObjeccts[i].activeInHierarchy)
                {
                    return poolObjeccts[i];
                }
            }
            return null;
        }
    }
}
