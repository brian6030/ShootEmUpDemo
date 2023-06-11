using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace root
{
    public class CameraController : MonoBehaviour

    {
        [SerializeField] Transform player;
        [Range(-10f, 10f)]
        [SerializeField] float speed = 2f;

        // Start is called before the first frame update
        // void Start() => transform.position = new Vector3(player.position.x, player.position.y, player.position.z);
        private void Start()
        {
            transform.position = new Vector3(player.position.x, player.position.y, gameObject.transform.position.z);
        }

        void LateUpdate()
        {
            // Update camera's position
            transform.position += Vector3.up * (speed * Time.deltaTime);
        }
    }
}
