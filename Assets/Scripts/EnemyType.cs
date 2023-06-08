using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace root
{
    [CreateAssetMenu(fileName = "EnemyType", menuName = "root/EnemyType", order = 0)]
    public class EnemyType : ScriptableObject
    {
        public GameObject enemyPrefab;
        public GameObject weaponPrefab;
        public float speed = 2f;
    }
}